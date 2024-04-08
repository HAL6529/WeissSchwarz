using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEraseDialog : MonoBehaviour
{
    public bool isOpen = false;

    public void Open()
    {
        isOpen = true;
        this.gameObject.SetActive(true);
    }

    public void OffDialog()
    {
        isOpen = false;
        this.gameObject.SetActive(false);
    }
}
