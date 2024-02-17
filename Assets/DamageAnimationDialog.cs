using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimationDialog : MonoBehaviour
{
    [SerializeField] List<DamageCardAnimation> DamageCardAnimationList = new List<DamageCardAnimation>();
    
    public void SetBattleModeCard(List<BattleModeCard> list)
    {
        if(list.Count == 0)
        {
            return;
        }

        this.gameObject.SetActive(true);
        for (int i = 0;i < DamageCardAnimationList.Count; i++)
        {
            if(i < list.Count - 1)
            {
                DamageCardAnimationList[i].AnimationStart(i, list[i], false);
            }
            else if(i == list.Count - 1)
            {
                DamageCardAnimationList[i].AnimationStart(i, list[i], true);
            }
            else
            {
                DamageCardAnimationList[i].NotAnimation();
            }
        }
    }

    public void OffDialog()
    {
        for (int i = 0; i < DamageCardAnimationList.Count; i++)
        {
            DamageCardAnimationList[i].NotAnimation();
        }
        this.gameObject.SetActive(false);
    }
}
