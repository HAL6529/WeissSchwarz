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

    private void Open()
    {
        m_BattleStrix.RpcToAll("NotEraseDialog", true, m_GameManager.isFirstAttacker);
        m_GameManager.isEncoreDialogProcess = true;
        this.gameObject.SetActive(true);
    }

    public void SetBattleModeCard(List<BattleModeCard> list)
    {
        int count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                images[i].sprite = Background;
                buttons[i].interactable = false;
                continue;
            }

            images[i].sprite = list[i].GetSprite();

            if (m_MyMainCardsManager.GetFieldPower(i) <= 0)
            {
                buttons[i].interactable = true;
                count++;
                continue;
            }

            buttons[i].interactable = false;
        }

        // パワー0のキャラがいてる場合それを先に解決
        if (count > 0)
        {
            Open();
            return;
        }

        // エンドフェーズの処理
        if (m_GameManager.isEndPhase)
        {
            count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null)
                {
                    images[i].sprite = Background;
                    buttons[i].interactable = false;
                    continue;
                }

                images[i].sprite = list[i].GetSprite();

                if (m_MyMainCardsManager.GetState(i) == EnumController.State.REVERSE)
                {
                    buttons[i].interactable = true;
                    count++;
                    continue;
                }

                buttons[i].interactable = false;
            }

            // パワー0のキャラがいてる場合それを先に解決
            if (count > 0)
            {
                Open();
                return;
            }

            Action TurnChange = new Action(m_GameManager, EnumController.Action.TurnChange);
            TurnChange.SetParamaterBattleStrix(m_BattleStrix);
            m_GameManager.ActionList.Add(TurnChange);
        }

        m_GameManager.ExecuteActionList();
    }

    public void SetBattleModeCardForEndPhase(List<BattleModeCard> list)
    {
        m_GameManager.isEndPhase = true;
        SetBattleModeCard(list);
    }

    /// <summary>
    /// アンコールするカードをクリックしたとき
    /// </summary>
    /// <param name="num"></param>
    public void onClick(int num)
    {
        m_BattleStrix.RpcToAll("NotEraseDialog", false, m_GameManager.isFirstAttacker);
        m_GameManager.isEncoreDialogProcess = false;
        BattleModeCard temp = m_GameManager.myFieldList[num];

        bool isStockThree = isExistStockThree();
        bool isStockTwo = isExistStockTwo();
        bool haveHandEncore = isHandEncore(num);
        bool haveClockEncore = isClockEncore(temp);

        m_MyMainCardsManager.CallPutGraveYardFromField(num);

        m_GameManager.Syncronize();
        this.gameObject.SetActive(false);

        int cnt = HaveParamater(EnumController.Action.TurnChange);

        if (m_GameManager.isEndPhase && cnt < 0)
        {
            Action TurnChange = new Action(m_GameManager, EnumController.Action.TurnChange);
            TurnChange.SetParamaterBattleStrix(m_BattleStrix);
            m_GameManager.ActionList.Add(TurnChange);
        }

        if (isStockThree == false && isStockTwo == false && haveHandEncore == false && haveClockEncore == false)
        {
            m_GameManager.ExecuteActionList();
        }
        else
        {
            m_DialogManager.ConfirmEncoreKindsDialog(temp, num, haveHandEncore, isStockTwo, isStockThree, haveClockEncore);
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

    private bool isHandEncore(int place)
    {
        if(m_MyMainCardsManager.isHandEncore(place) && m_GameManager.myHandList.Count > 0)
        {
            return true;
        }
        return false;
    }

    private bool isClockEncore(BattleModeCard card)
    {
        return false;
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }

    private int HaveParamater(EnumController.Action paramater)
    {
        for (int i = 0; i < m_GameManager.ActionList.Count; i++)
        {
            if (m_GameManager.ActionList[i].GetParamater() == paramater)
            {
                return i;
            }
        }
        return -1;
    }
}
