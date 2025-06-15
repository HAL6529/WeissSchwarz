using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectDialog : MonoBehaviour
{
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] EnemyMainCardsManager m_EnemyMainCardsManager;
    [SerializeField] GameObject m_OKButton;
    [SerializeField] Sprite BackImage;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] DialogManager m_DialogManager;
    [SerializeField] RectTransform m_RectTransform;
    private int place = -1;

    /// <summary>
    /// �Œ�I�΂Ȃ��Ƃ����Ȃ������A��`���Ȃ����-1
    /// </summary>
    private int minNum = -1;

    /// <summary>
    /// �ő�I�ׂ閇���A��`���Ȃ����-1
    /// </summary>
    private int maxNum = -1;

    private int ButtonSelectedNum = -1;
    private List<bool> ButtonSelectedNumList = new List<bool> { false, false, false, false, false, };
    private EnumController.Attack status = EnumController.Attack.VOID;
    private BattleModeCard m_BattleModeCard = null;

    public void Open(BattleModeCard card, bool isMine, int place)
    {
        List<BattleModeCard> list = new List<BattleModeCard>();
        if (isMine)
        {
            list = m_GameManager.myFieldList;
            m_RectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            list = m_GameManager.enemyFieldList;
            m_RectTransform.rotation = Quaternion.Euler(0, 0, 180.0f);
        }
        m_OKButton.SetActive(false);
        ButtonSelectedNum = -1;
        ButtonSelectedNumList = new List<bool> { false, false, false, false, false, };
        this.place = place;
        this.status = status;
        m_BattleModeCard = card;
        int cnt = 0;

        // �Œ�I�΂Ȃ��Ƃ����Ȃ��J�[�h�̖����ƍő�I�ׂ�J�[�h�̖����̒�`�ݒ�
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A02:
            case EnumController.CardNo.DC_W01_05T:
            case EnumController.CardNo.DC_W01_18T:
            case EnumController.CardNo.LB_W02_02T:
            case EnumController.CardNo.LB_W02_09T:
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_12T:
                minNum = 1;
                maxNum = 1;
                break;
            case EnumController.CardNo.DC_W01_07T:
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_11T:
                minNum = 0;
                maxNum = 1;
                break;
            case EnumController.CardNo.LB_W02_04T:
                minNum = -1;
                maxNum = 2;
                break;
            default:
                break;
        }


        for (int i = 0; i < images.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = BackImage;
                cnt++;
                buttons[i].interactable = false;
            }
            else
            {
                images[i].sprite = list[i].sprite;
                if (i == place)
                {
                    buttons[i].interactable = false;
                }
                else
                {
                    buttons[i].interactable = true;
                }

                switch (m_BattleModeCard.cardNo)
                {
                    // �O��̃J�[�h�����Ώ�
                    case EnumController.CardNo.DC_W01_05T:
                        if(i >= 3)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    // ���x��1�ȉ��̃L�����̂ݑΏ�
                    case EnumController.CardNo.DC_W01_18T:
                        if (m_EnemyMainCardsManager.GetFieldLevel(i) > 1)
                        {
                            buttons[i].interactable = false;
                            cnt++;
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        switch (m_BattleModeCard.cardNo)
        {
            // �ق��ɃL�����N�^�[�����Ȃ����return����
            case EnumController.CardNo.AT_WX02_A02:
                if (cnt >= 4)
                {
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    OffDialog();
                    return;
                }
                break;
            // �L�����N�^�[�����Ȃ����return����
            case EnumController.CardNo.DC_W01_05T:
            case EnumController.CardNo.DC_W01_07T:
            case EnumController.CardNo.DC_W01_18T:
            case EnumController.CardNo.LB_W02_02T:
            case EnumController.CardNo.LB_W02_09T:
            case EnumController.CardNo.P3_S01_01T:
            case EnumController.CardNo.P3_S01_04T:
            case EnumController.CardNo.P3_S01_11T:
            case EnumController.CardNo.P3_S01_12T:
                if (cnt >= 5)
                {
                    m_GameManager.Syncronize();
                    m_GameManager.ExecuteActionList();
                    OffDialog();
                    return;
                }
                break;
            default:
                break;
        }
        this.gameObject.SetActive(true);
    }

    public void ButtonClick(int num)
    {
        if (ButtonSelectedNumList[num])
        {
            images[num].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
            ButtonSelectedNumList[num] = false;
        }
        else
        {
            images[num].color = new Color(145f / 255f, 145f / 255f, 145f / 255f, 145f / 255f);
            ButtonSelectedNumList[num] = true;
        }

        //OK�{�^�����A�N�e�B�u�ɂ��邩����
        int cnt = 0;
        for(int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (ButtonSelectedNumList[i])
            {
                cnt++;
            }
        }

        if(cnt < minNum || maxNum < cnt)
        {
            m_OKButton.SetActive(false);
        }
        else
        {
            m_OKButton.SetActive(true);
        }
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = new Color(1, 255 / 255, 255 / 255, 255 / 255);
        }
        status = EnumController.Attack.VOID;
        place = -1;
        ButtonSelectedNum = -1;
    }

    public void OKButton()
    {
        int power = 0;
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.P3_S01_12T:
                power = 3000;
                break;
            case EnumController.CardNo.P3_S01_04T:
                power = 2000;
                break;
            case EnumController.CardNo.AT_WX02_A02:
            case EnumController.CardNo.LB_W02_02T:
                power = 1500;
                break;
            case EnumController.CardNo.DC_W01_07T:
            case EnumController.CardNo.LB_W02_04T:
                power = 1000;
                break;
            case EnumController.CardNo.LB_W02_09T:
                power = -500;
                break;
            case EnumController.CardNo.DC_W01_05T:
                power = -1000;
                break;
            default:
                break;
        }

        for (int i = 0; i < ButtonSelectedNumList.Count; i++)
        {
            if (!ButtonSelectedNumList[i])
            {
                continue;
            }
            switch (m_BattleModeCard.cardNo)
            {
                case EnumController.CardNo.AT_WX02_A02:
                case EnumController.CardNo.DC_W01_07T:
                case EnumController.CardNo.LB_W02_02T:
                case EnumController.CardNo.LB_W02_04T:
                    // �����̃J�[�h�̃p���[�𑀍삷��
                    if (ButtonSelectedNumList[i])
                    {
                        m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
                    }
                    break;
                case EnumController.CardNo.DC_W01_05T:
                case EnumController.CardNo.LB_W02_09T:
                    // ����̃J�[�h�̃p���[�𑀍삷��
                    if (ButtonSelectedNumList[i])
                    {
                        m_BattleStrix.RpcToAll("CallAddPowerUpUntilTurnEnd", m_GameManager.isTurnPlayer, i, power);
                    }
                    break;
                case EnumController.CardNo.DC_W01_18T:
                    // ����̃J�[�h���T���ɑ���
                    if (ButtonSelectedNumList[i])
                    {
                        m_BattleStrix.RpcToAll("ToGraveYardFromField", i, m_GameManager.isTurnPlayer);
                    }
                    break;
                case EnumController.CardNo.P3_S01_01T:
                case EnumController.CardNo.P3_S01_11T:
                    // ����̃J�[�h���o�E���X����
                    if (ButtonSelectedNumList[i])
                    {
                        m_BattleStrix.RpcToAll("ToHandFromField", i, m_GameManager.isTurnPlayer);
                    }
                    break;
                case EnumController.CardNo.P3_S01_04T:
                case EnumController.CardNo.P3_S01_12T:
                    // �����̃J�[�h�̃p���[�ƃ\�E���𑀍삷��
                    m_MyMainCardsManager.AddSoulUpUntilTurnEnd(i, 1);
                    m_MyMainCardsManager.AddPowerUpUntilTurnEnd(i, power);
                    m_GameManager.Syncronize();
                    break;
                default:
                    break;
            }

        }

        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_05T:
            case EnumController.CardNo.LB_W02_09T:
                Action action = new Action(m_GameManager, EnumController.Action.EncoreCheck);
                action.SetParamaterDialogManager(m_DialogManager);

                m_GameManager.ActionList.Add(action);
                break;
            default:
                break;
        }

        // �C�x���g�J�[�h�̏ꍇ�͏�����ɍT���ɃJ�[�h��ǉ�
        switch (m_BattleModeCard.cardNo)
        {
            case EnumController.CardNo.DC_W01_18T:
            case EnumController.CardNo.LB_W02_04T:
            case EnumController.CardNo.P3_S01_12T:
                m_GameManager.myHandList.Remove(m_BattleModeCard);
                m_GameManager.GraveYardList.Add(m_BattleModeCard);
                break;
            default:
                break;
        }
        m_GameManager.Syncronize();

        m_GameManager.ExecuteActionList();
        OffDialog();
    }
}