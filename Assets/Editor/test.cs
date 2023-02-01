using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class test : MonoBehaviour
{
    GameObject parent;
    GameObject[] children;

    private void Awake()
    {
        parent = GameObject.FindGameObjectWithTag("Path");
        children = GetChildren(parent);
        Order(true);
    }

    void Order(bool isAscending)
    {
        if (isAscending)
            children = children.OrderBy(go => go.name).ToArray();

        else
            children = children.OrderByDescending(go => go.name).ToArray();

        for (int i = 0; i < children.Length; i++)
        {
            children[i].transform.SetSiblingIndex(i);
        }
    }

    private GameObject[] GetChildren(GameObject _parent)
    {
        GameObject[] _children = new GameObject[_parent.transform.childCount];

        for (int i = 0; i < _children.Length; i++)
        {
            _children[i] = _parent.transform.GetChild(i).gameObject;
        }

        return _children;
    }
}
