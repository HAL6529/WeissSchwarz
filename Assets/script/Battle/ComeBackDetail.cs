using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeBackDetail : MonoBehaviour
{
    [SerializeField] List<ComeBackButtonUtil> BtnList = new List<ComeBackButtonUtil>();
    [SerializeField] GameObject OkButton;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    [SerializeField] ConfirmSearchOrSulvageCardDialog m_ConfirmSearchOrSulvageCardDialog;
    private BattleModeCard m_BattleModeCard = null;
    private int damage = -1;
    private int place = -1;
    private bool isFirstAttacker = false;
    private EnumController.Damage damageParamater = EnumController.Damage.VOID;
    private List<EnumController.Shot> SendShotList = new List<EnumController.Shot>();

    /// <summary>
    /// フロントアタック用
    /// </summary>
    /// <param name="list"></param>
    /// <param name="damage"></param>
    /// <param name="place"></param>
    /// <param name="isFirstAttacker"></param>
    public void SetBattleModeCard(List<BattleModeCard> list, int damage, int place, bool isFirstAttacker, List<EnumController.Shot> SendShotList)
    {
        m_BattleModeCard = null;
        this.damage = damage;
        this.place = place;
        this.isFirstAttacker = isFirstAttacker;
        this.damageParamater = EnumController.Damage.FRONT_ATTACK;
        this.SendShotList = SendShotList;
        List<BattleModeCard> tempList = new List<BattleModeCard>();
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i].type == EnumController.Type.CHARACTER)
            {
                tempList.Add(list[i]);
            }
        }

        // 回収するカードがない場合
        if(tempList.Count == 0 || m_GameManager.myDeckList.Count <= 1)
        {
            m_GameManager.TriggerAfter();
            m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, place, isFirstAttacker, SendShotList);
            return;
        }

        this.gameObject.SetActive(true);
        OkButton.SetActive(false);

        for (int i = 0; i < BtnList.Count; i++)
        {
            if(i < tempList.Count)
            {
                BtnList[i].setBattleModeCard(tempList[i]);
            }
            else
            {
                BtnList[i].setBattleModeCard(null);
            }
        }
    }

    /// <summary>
    /// サイドアタックとダイレクトアタック用
    /// </summary>
    /// <param name="list"></param>
    /// <param name="damage"></param>
    /// <param name="isFirstAttacker"></param>
    /// <param name="damageParamater"></param>
    public void SetBattleModeCard(List<BattleModeCard> list, int damage, bool isFirstAttacker, EnumController.Damage damageParamater, List<EnumController.Shot> SendShotList)
    {
        m_BattleModeCard = null;
        this.damage = damage;
        this.place = -1;
        this.isFirstAttacker = isFirstAttacker;
        this.damageParamater = damageParamater;
        this.SendShotList = SendShotList;
        List<BattleModeCard> tempList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].type == EnumController.Type.CHARACTER)
            {
                tempList.Add(list[i]);
            }
        }

        // 回収するカードがない場合
        if (tempList.Count == 0 || m_GameManager.myDeckList.Count <= 1)
        {
            m_GameManager.TriggerAfter();
            m_BattleStrix.RpcToAll("Damage", damage, isFirstAttacker, damageParamater, SendShotList);
            return;
        }

        this.gameObject.SetActive(true);
        OkButton.SetActive(false);

        for (int i = 0; i < BtnList.Count; i++)
        {
            if (i < tempList.Count)
            {
                BtnList[i].setBattleModeCard(tempList[i]);
            }
            else
            {
                BtnList[i].setBattleModeCard(null);
            }
        }
    }

    public void Setm_BattleModeCard(BattleModeCard card)
    {
        m_BattleModeCard = card;
        SwitchOKbutton();
    }

    public void ResetComeBackButtonUtilsIsSelected()
    {
        for (int i = 0; i < BtnList.Count; i++)
        {
            BtnList[i].FalseIsSelected();
        }
    }

    private void SwitchOKbutton()
    {
        if(m_BattleModeCard == null)
        {
            OkButton.SetActive(false);
        }
        else
        {
            OkButton.SetActive(true);
        }

    }

    public void onOKButton()
    {
        if(m_BattleModeCard == null)
        {
            return;
        }
        if(damageParamater == EnumController.Damage.VOID)
        {
            return;
        }

        List<BattleModeCard> graveyardTemp = m_GameManager.GraveYardList;
        List<BattleModeCard> handListTemp = m_GameManager.myHandList;
        List<BattleModeCard> sulvageListTemp = new List<BattleModeCard>();
        sulvageListTemp.Add(m_BattleModeCard);

        graveyardTemp.Remove(m_BattleModeCard);
        handListTemp.Add(m_BattleModeCard);

        List<BattleModeCardTemp> m_graveyardTemp = new List<BattleModeCardTemp>();
        List<BattleModeCardTemp> m_handListTemp = new List<BattleModeCardTemp>();
        for (int i = 0; i < graveyardTemp.Count; i++)
        {
            m_graveyardTemp.Add(new BattleModeCardTemp(graveyardTemp[i]));
        }
        for (int i = 0; i < handListTemp.Count; i++)
        {
            m_handListTemp.Add(new BattleModeCardTemp(handListTemp[i]));
        }

        ExecuteActionTemp m_ExecuteActionTemp = new ExecuteActionTemp();
        m_ExecuteActionTemp.damageParamater = damageParamater;
        m_ExecuteActionTemp.graveyardList = m_graveyardTemp;
        m_ExecuteActionTemp.handList = m_handListTemp;
        m_ExecuteActionTemp.intParamater = damage;
        m_ExecuteActionTemp.intParamater2 = place;
        m_ExecuteActionTemp.isFirstAttacker = isFirstAttacker;
        m_ExecuteActionTemp.SendShotList = SendShotList;

        m_BattleStrix.SendConfirmSearchOrSulvageCardDialog(sulvageListTemp, EnumController.ConfirmSearchOrSulvageCardDialog.COMEBACK, m_ExecuteActionTemp, isFirstAttacker);
        this.gameObject.SetActive(false);
    }

    public void onCloseButton()
    {
        m_GameManager.TriggerAfter();
        m_BattleStrix.RpcToAll("Damage", damage, isFirstAttacker, damageParamater, SendShotList);
        this.gameObject.SetActive(false);
        return;
    }
}
