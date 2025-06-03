using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialog : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons = new List<GameObject>();
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] EventAnimationManager m_EventAnimationManager;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyHandCardsManager m_MyHandCardsManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameObject OKButton;

    private List<bool> isSelected = new List<bool>{false, false, false, false, false };
    private int place = -1;
    private BattleModeCard m_BattleModeCard = null;
    public Effect m_Effect;

    void Start()
    {
        m_Effect = new Effect(m_GameManager, m_BattleStrix);
        m_Effect.m_EventAnimationManager = m_EventAnimationManager;
    }

    public void onClick(int num)
    {
        // ���ɑI�΂�Ă���ꍇ
        if (isSelected[num])
        {
            OKButton.SetActive(false);
            images[num].color = new Color(1, 1, 255 / 255, 255 / 255);
            isSelected[num] = false;
            return;
        }

        // �I�΂�Ă��Ȃ��ꍇ
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
        if (m_BattleModeCard != null)
        {
            for(int i = 0; i < m_BattleModeCard.cost; i++)
            {
                BattleModeCard temp = m_GameManager.myStockList[m_GameManager.myStockList.Count - 1];
                m_GameManager.GraveYardList.Add(temp);
                m_GameManager.myStockList.Remove(temp);
            }
            m_MyMainCardsManager.CallPutFieldFromHand(place, m_BattleModeCard, EnumController.State.STAND);
        }
        m_MyHandCardsManager.CallNotShowPlayButton();
        OffMainDialog();

        // �J�[�h�̓o�ꎞ�̌��ʋN��
        m_Effect.BondForHandToFild(m_BattleModeCard);
        m_Effect.WhenPlaceCardEffect(m_BattleModeCard, place);

        // �p���[�A���x���A�����A�\�E���̌v�Z
        m_MyMainCardsManager.FieldPowerAndLevelAndAttributeAndSoulReset();

        // �u�y���z ���̂��Ȃ��̃L�������v���C����ĕ���ɒu���ꂽ���v�ɔ���������ʂ������Ă���J�[�h����ɂȂ����m�F����
        m_MyMainCardsManager.ConfirmEffectWhenMyCardPut(place);

        m_GameManager.ExecuteActionList();
    }

    public void onCloseButton()
    {
        OffMainDialog();
        m_MyHandCardsManager.CallNotShowPlayButton();
        m_MyMainCardsManager.CallNotShowMoveButton();
    }

    public void SetBattleMordCard(BattleModeCard card)
    {
        ResetSelectZone();
        this.gameObject.SetActive(true);
        m_BattleModeCard = card;
    }

    /// <summary>
    /// ���C���_�C�A���O�����
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
