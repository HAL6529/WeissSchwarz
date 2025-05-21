using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulInstance 
{
    /// <summary>
    /// �^�[���I�����܂ŃA�b�v����\�E���N���X
    /// </summary>
    public class SoulUpUntilTurnEnd
    {
        private int UpSoul = 0;

        public SoulUpUntilTurnEnd(int num)
        {
            UpSoul = num;
        }

        public int GetUpSoul()
        {
            return UpSoul;
        }

        public void AddUpSoul(int num)
        {
            UpSoul += num;
        }

        public void ResetUpSoul()
        {
            UpSoul = 0;
        }
    }
}
