using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startBalance = 150;
    [SerializeField] private int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance
    {
        get { return currentBalance; }
    }

    private void Awake()
    {
        currentBalance = startBalance;
        UpdateDisplayBalance();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplayBalance();
    }

    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplayBalance();

        if (currentBalance < 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    private void UpdateDisplayBalance()
    {
        displayBalance.text = $"Gold> {currentBalance}";
    }
}