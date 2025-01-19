using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmEnemyHandDialog : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] List<Image> imageList = new List<Image>();
    [SerializeField] List<GameObject> buttonList = new List<GameObject>();
    [SerializeField] BattleModeGuide m_BattleModeGuide;

    private List<BattleModeCard> BattleModeCardList = new List<BattleModeCard>();

    public void SetBattleModeCardList(List<BattleModeCard> list)
    {
        BattleModeCardList = new List<BattleModeCard>();
        BattleModeCardList = list;
        for(int i = 0; i < imageList.Count; i++)
        {
            if(i > BattleModeCardList.Count - 1)
            {
                buttonList[i].SetActive(false);
            }
            else
            {
                buttonList[i].SetActive(true);
                imageList[i].sprite = BattleModeCardList[i].sprite;
            }
        }

        this.gameObject.SetActive(true);
    }

    public void onCardBtn(int num)
    {
        m_BattleModeGuide.showImage(BattleModeCardList[num]);
    }

    public void onOKBtn()
    {
        OffDialog();
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
