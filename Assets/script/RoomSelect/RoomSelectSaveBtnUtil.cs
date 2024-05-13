using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelectSaveBtnUtil : MonoBehaviour
{
    [SerializeField] DeckListManager m_DeckListManager;
    SaveUtil m_SaveUtil = new SaveUtil();

    public void onClick()
    {
        m_SaveUtil.SetDeckList(m_DeckListManager.GetDeckList());
        m_SaveUtil.Save();
    }
}
