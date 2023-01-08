using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialog : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons = new List<GameObject>();
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;

    private List<bool> isSelected = new List<bool>{false, false, false, false, false };
    private int place = -1;
    private BattleModeCard m_BattleModeCard = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(int num)
    {
        // ���ɑI�΂�Ă���ꍇ
        if (isSelected[num])
        {
            images[num].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[num] = false;
            return;
        }

        // �I�΂�Ă��Ȃ��ꍇ
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[i] = false;
        }
        images[num].color = new Color(1, 1, 0 / 255, 255 / 255);
        isSelected[num] = true;
        place = num;
    }

    public void onOkClick()
    {
        if(place == -1)
        {
            return;
        }
        if (m_BattleModeCard != null)
        {
            m_GameManager.myMainList[place] = m_BattleModeCard;
            m_GameManager.myHandList.Remove(m_BattleModeCard);
            m_GameManager.UpdateMyHandCards();
        }
        OffMainDialog();
        m_MyHandCardsManager.CallNotShowPlayButton();
    }

    public void SetBattleMordCard(BattleModeCard card)
    {
        this.gameObject.SetActive(true);
        // �I�΂�Ă��Ȃ��ꍇ
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[i] = false;
        }
        isSelected = new List<bool> {false, false, false, false, false};        
        place = -1;
        m_BattleModeCard = card;
    }

    /// <summary>
    /// ���C���_�C�A���O�����
    /// </summary>
    public void OffMainDialog()
    {
        this.gameObject.SetActive(false);
    }
}
