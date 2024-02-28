using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEraseDialog : MonoBehaviour
{
    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
