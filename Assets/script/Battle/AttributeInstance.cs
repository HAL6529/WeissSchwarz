using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttributeInstance
{
    /// <summary>
    /// ターン終了時まで変動する特徴クラス
    /// </summary>
    public class AttributeUpUntilTurnEnd
    {
        public List<EnumController.Attribute> AttributeList = new List<EnumController.Attribute>();

        public AttributeUpUntilTurnEnd()
        {

        }

        public AttributeUpUntilTurnEnd(List<EnumController.Attribute> AttributeList)
        {
            this.AttributeList = AttributeList;
        }

        public void AddAttribute(EnumController.Attribute attribute)
        {
            this.AttributeList.Add(attribute);
        }

        public void ResetAttribute()
        {
            this.AttributeList = new List<EnumController.Attribute>();
        }
    }
}
