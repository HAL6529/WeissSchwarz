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
    [SerializeField] GameObject OKButton;

    private List<bool> isSelected = new List<bool>{false, false, false, false, false };
    private int place = -1;
    private BattleModeCard m_BattleModeCard = null;

    private DialogMode mode = DialogMode.VOID;

    private enum DialogMode
    {
        VOID,
        HandToField,
        MainMove
    }

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
        // 既に選ばれている場合
        if (isSelected[num])
        {
            OKButton.SetActive(false);
            images[num].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[num] = false;
            return;
        }

        // 選ばれていない場合
        for (int i = 0; i < images.Count; i++)
        {
            OKButton.SetActive(true);
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[i] = false;
        }
        images[num].color = new Color(1, 1, 0 / 255, 255 / 255);
        isSelected[num] = true;
        place = num;
    }

    public void onOkClick()
    {
        if (place == -1)
        {
            return;
        }
        if (mode == DialogMode.HandToField)
        {
            if (m_BattleModeCard != null)
            {
                m_GameManager.myFieldList[place] = m_BattleModeCard;
                m_GameManager.myHandList.Remove(m_BattleModeCard);
                m_GameManager.UpdateMyHandCards();
                m_GameManager.UpdateMyMainCards();
            }
            m_MyHandCardsManager.CallNotShowPlayButton();
        }
        OffMainDialog();
    }

    public void MoveMode(BattleModeCard card)
    {
        mode = DialogMode.MainMove;
        ResetSelectZone();
        this.gameObject.SetActive(true);
    }

    public void SetBattleMordCard(BattleModeCard card)
    {
        mode = DialogMode.HandToField;
        ResetSelectZone();
        this.gameObject.SetActive(true);
        m_BattleModeCard = card;
    }

    /// <summary>
    /// メインダイアログを閉じる
    /// </summary>
    public void OffMainDialog()
    {
        this.gameObject.SetActive(false);
    }

    private void ResetSelectZone()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[i] = false;
        }
        OKButton.SetActive(false);
        isSelected = new List<bool> { false, false, false, false, false };
        place = -1;
    }
}
