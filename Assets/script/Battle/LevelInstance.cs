using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelInstance 
{
    /// <summary>
    /// �^�[���I�����܂ŃA�b�v���郌�x���N���X
    /// </summary>
    public class LevelUpUntilTurnEnd
    {
        private int UpLevel = 0;

        public LevelUpUntilTurnEnd(int num)
        {
            UpLevel = num;
        }

        public int GetUpLevel()
        {
            return UpLevel;
        }

        public void AddUpLevel(int num)
        {
            UpLevel += num;
        }

        public void ResetUpLevel()
        {
            UpLevel = 0;
        }
    }
}
