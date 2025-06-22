using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHide : MonoBehaviour
{
    [SerializeField] GameObject CharacterSelectDialog;

    public void onMaximumBtn()
    {
        this.gameObject.SetActive(false);
        CharacterSelectDialog.SetActive(true);
    }
}
