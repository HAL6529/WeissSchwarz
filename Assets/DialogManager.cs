using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] MainDialog m_MainDialog;
    [SerializeField] MoveDialog m_MoveDialog;
    [SerializeField] ClockDialog m_ClockDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseAllDialog()
    {
        m_MainDialog.OffMainDialog();
        m_MoveDialog.OffMainDialog();
        m_ClockDialog.ClockDialogEnd();
    }
}
