using System;
using UnityEngine;
using UnityEngine.UI;

public class NavigationUI : MonoBehaviour
{
    [SerializeField] Button navLeftButton, navRightButton;
    public void Navigate(int direction)
    {
        var index = GetIndexObjectActive();
        transform.GetChild(index).gameObject.SetActive(false);
        transform.GetChild(index + direction).gameObject.SetActive(true);
    }

    private int GetIndexObjectActive()
    {
        int index =0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                index= i;
            }
        }

        return index;
    }

    private void Update()
    {
        if(GetIndexObjectActive()<=0)
        {
            navLeftButton.interactable = false;
        }
        else
        {
            navLeftButton.interactable = true;
        }
        if(GetIndexObjectActive()>=transform.childCount-1)
        {
            navRightButton.interactable = false;
        }
        else
        {
            navRightButton.interactable = true;
        }
    }
}
