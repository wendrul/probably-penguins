using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    int i;
    private GameObject[] page;

    private void Start()
    {
        page = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            page[i] = transform.GetChild(i).gameObject;
        }
    }

    public void NextPage()
    {
        if (i < transform.childCount - 2)
        {
            transform.GetChild(i).gameObject.SetActive(false);
            i++;
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if (i > 0)
        {       
            transform.GetChild(i).gameObject.SetActive(false);
            i--;
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
