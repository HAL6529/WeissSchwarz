using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerInstance 
{
    public class Assist
    {
        private int AssistPower = 0;

        public Assist(int num)
        {
            AssistPower = num;
        }

        public int getAssistPower()
        {
            return AssistPower;
        }

        public void Reset()
        {
            AssistPower = 0;
        }
    }

    public class AllAssist
    {
        private List<EnumController.Attribute> AttributeList;

        private int AssistPower = 0;

        public AllAssist(int num, List<EnumController.Attribute> attribute)
        {
            AssistPower = num;
            AttributeList = attribute;
        }

        public int getAssistPower()
        {
            return AssistPower;
        }

        public void Reset()
        {
            AttributeList = new List<EnumController.Attribute>();
            AssistPower = 0;
        }
    }
}