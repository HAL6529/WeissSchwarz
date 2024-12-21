using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitDialog : MonoBehaviour
{
    public void onClose()
    {
        this.gameObject.SetActive(false);
    }

    public void onOpen()
    {
        this.gameObject.SetActive(true);
    }
}
