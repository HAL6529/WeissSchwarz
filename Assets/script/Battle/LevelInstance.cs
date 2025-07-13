using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelInstance 
{
    /// <summary>
    /// ターン終了時までアップするレベルクラス
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
