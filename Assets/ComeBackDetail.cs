using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeBackDetail : MonoBehaviour
{
    [SerializeField] List<ComeBackButtonUtil> BtnList = new List<ComeBackButtonUtil>();
    [SerializeField] GameObject OkButton;
    [SerializeField] BattleStrix m_BattleStrix;
    [SerializeField] GameManager m_GameManager;
    private BattleModeCard m_BattleModeCard = null;
    private int damage = -1;
    private int place = -1;
    private bool isFirstAttacker = false;
    private EnumController.Damage damageParamater = EnumController.Damage.VOID;

    /// <summary>
    /// フロントアタック用
    /// </summary>
    /// <param name="list"></param>
    /// <param name="damage"></param>
    /// <param name="place"></param>
    /// <param name="isFirstAttacker"></param>
    public void SetBattleModeCard(List<BattleModeCard> list, int damage, int place, bool isFirstAttacker)
    {
        m_BattleModeCard = null;
        this.damage = damage;
        this.place = place;
        this.isFirstAttacker = isFirstAttacker;
        this.damageParamater = EnumController.Damage.FRONT_ATTACK;
        List<BattleModeCard> tempList = new List<BattleModeCard>();
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i].type == EnumController.Type.CHARACTER)
            {
                tempList.Add(list[i]);
            }
        }

        if(tempList.Count == 0)
        {
            m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, place, isFirstAttacker);
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
    public void SetBattleModeCard(List<BattleModeCard> list, int damage, bool isFirstAttacker, EnumController.Damage damageParamater)
    {
        m_BattleModeCard = null;
        this.damage = damage;
        this.place = -1;
        this.isFirstAttacker = isFirstAttacker;
        this.damageParamater = damageParamater;
        List<BattleModeCard> tempList = new List<BattleModeCard>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].type == EnumController.Type.CHARACTER)
            {
                tempList.Add(list[i]);
            }
        }

        if (tempList.Count == 0)
        {
            m_BattleStrix.RpcToAll("Damage", damage, isFirstAttacker, damageParamater);
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

        m_GameManager.myHandList.Add(m_BattleModeCard);
        m_GameManager.GraveYardList.Remove(m_BattleModeCard);
        m_GameManager.Syncronize();
        this.gameObject.SetActive(false);
        if(damageParamater == EnumController.Damage.FRONT_ATTACK)
        {
            m_BattleStrix.RpcToAll("CallOKDialogForCounter", damage, place, isFirstAttacker);
            return;
        }
        m_BattleStrix.RpcToAll("Damage", damage, isFirstAttacker, damageParamater);
    }
}
