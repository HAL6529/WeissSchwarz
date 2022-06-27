using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filterDialog : MonoBehaviour
{
    private bool isOpened = false;

    private void onActive()
    {
        if (!isOpened)
        {
            this.gameObject.SetActive(true);
        }
        isOpened = true;
        return;
    }

    private void onInActive()
    {
        if (isOpened)
        {
            this.gameObject.SetActive(false);
        }
        isOpened = false;
        return;
    }

    public void closeFilter()
    {
        onInActive();
    }

    public void openFilter()
    {
        onActive();
    }
}
