using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteActionTemp
{
    public EnumController.Damage damageParamater { get; set; }
    public List<BattleModeCardTemp> deckList { get; set; }
    public List<BattleModeCardTemp> memoryList { get; set; }
    public List<BattleModeCardTemp> stockList { get; set; }
    public List<BattleModeCardTemp> graveyardList { get; set; }
    public List<BattleModeCardTemp> clockList { get; set; }
    public List<BattleModeCardTemp> handList { get; set; }
    public BattleModeCardTemp eventCard { get; set; }
    public int intParamater { get; set; }
    public int intParamater2 { get; set; }
    public bool isFirstAttacker { get; set; }
    public List<EnumController.Shot> SendShotList { get; set; }
}
