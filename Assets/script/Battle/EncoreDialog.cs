using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncoreDialog : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<Image> images = new List<Image>();
    [SerializeField] GameManager m_GameManager;
    [SerializeField] MyMainCardsManager m_MyMainCardsManager;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameObject OKButton;
    [SerializeField] Sprite Background;
    [SerializeField] DialogManager m_DialogManager;

    private EnumController.EncoreDialog paramater= EnumController.EncoreDialog.VOID;

    private void Open()
    {
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
        this.gameObject.SetActive(true);
    }

    public void SetBattleModeCard(List<BattleModeCard> list, EnumController.EncoreDialog p)
    {
        int count = 0;
        paramater = p;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = Background;
                buttons[i].interactable = false;
                continue;
            }

            images[i].sprite = list[i].sprite;

            switch (paramater)
            {
                case EnumController.EncoreDialog.EncorePhase:
                    if (m_MyMainCardsManager.GetState(i) == EnumController.State.REVERSE)
                    {
                        buttons[i].interactable = true;
                        count++;
                        continue;
                    }
                    break;
                case EnumController.EncoreDialog.EncoreCheck:
                    if (m_MyMainCardsManager.GetFieldPower(i) <= 0)
                    {
                        buttons[i].interactable = true;
                        count++;
                        continue;
                    }
                    break;
                default:
                    break;
            }

            buttons[i].interactable = false;
        }
        if(count == 0)
        {
            switch (paramater)
            {
                case EnumController.EncoreDialog.EncorePhase:
                    //ターンプレイヤーを先に解決し、非ターンプレイヤーの場合はターンチェンジする
                    if (m_GameManager.isTurnPlayer)
                    {
                        m_BattleStrix.RpcToAll("EncoreDialog", m_GameManager.isFirstAttacker, paramater);
                    }
                    else
                    {
                        m_GameManager.TurnChange();
                    }
                    return;
                case EnumController.EncoreDialog.EncoreCheck:
                    //ターンプレイヤーを先に解決し、非ターンプレイヤーの場合はターンチェンジする
                    if (m_GameManager.isTurnPlayer)
                    {
                        m_BattleStrix.RpcToAll("EncoreDialog", m_GameManager.isFirstAttacker, paramater);
                    }
                    else
                    {
                        m_BattleStrix.RpcToAll("CallExecuteActionList", m_GameManager.isFirstAttacker);
                    }
                    return;
                default:
                    break;
            }
        }
        Open();
    }

    /// <summary>
    /// アンコールするカードをクリックしたとき
    /// </summary>
    /// <param name="num"></param>
    public void onClick(int num)
    {
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        BattleModeCard temp = m_GameManager.myFieldList[num];
        m_GameManager.GraveYardList.Add(m_GameManager.myFieldList[num]);
        m_GameManager.myFieldList[num] = null;

        m_MyMainCardsManager.setBattleModeCard(num, null, EnumController.State.STAND);
        m_MyMainCardsManager.ResetPowerUpUntilTurnEnd(num);
        //--------------------------------------------------------------------------------------
        //ここに控室にカードが置かれたときに発動する効果を確認する処理を入れるべきだと思われる
        //--------------------------------------------------------------------------------------

        m_GameManager.Syncronize();
        this.gameObject.SetActive(false);

        bool isStockThree = isExistStockThree();
        bool isStockTwo = isExistStockTwo();
        bool haveHandEncore = isHandEncore(temp);
        bool haveClockEncore = isClockEncore(temp);

        if (isStockThree == false && isStockTwo == false && haveHandEncore == false && haveClockEncore == false)
        {
            m_DialogManager.EncoreDialog(m_GameManager.myFieldList, paramater);
        }
        else
        {
            m_DialogManager.ConfirmEncoreKindsDialog(temp, num, paramater, haveHandEncore, isStockTwo, isStockThree, haveClockEncore);
        }
        return;
    }

    private bool isExistStockThree()
    {
        if (m_GameManager.myStockList.Count > 2)
        {
            return true;
        }
        return false;
    }

    private bool isExistStockTwo()
    {
        return false;
    }

    private bool isHandEncore(BattleModeCard card)
    {
        switch (card.cardNo)
        {
            case EnumController.CardNo.AT_WX02_A04:
            case EnumController.CardNo.LB_W02_03T:
                return true;
            default:
                return false;
        }
    }

    private bool isClockEncore(BattleModeCard card)
    {
        return false;
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
