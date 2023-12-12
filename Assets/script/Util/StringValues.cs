using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringValues
{
    private EnumController.Language paramater = EnumController.Language.Japanese;

    Japanese japanese = new Japanese();

    public string OKDialog_Clock;
    public string OKDialog_Marigan;
    public string HandOverDialog;
    public string YesOrNoDialog_CLIMAX_PHASE;
    public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
    public string AT_WX02_A01_Explanation = "";
    public string AT_WX02_A02_Explanation = "【AUTO】 When this card attacks, choose 1 of your other characters, and that character gets +1500 power until end of turn.";
    public string AT_WX02_A03_Explanation = "【AUTO】 【CXCOMBO】 When this card's battle opponent becomes 【REVERSE】, if [Memory of a Memory] is in your climax area, you may draw 1 card.";
    public string AT_WX02_A04_Explanation = "【AUTO】 Encore [Put 1 character from your hand into your waiting room] (When this card is put into your waiting room from the stage, you may pay the cost. If you do, return this card to its previous stage position as 【REST】)";
    public string AT_WX02_A05_Explanation = "【ACT】 【COUNTER】 Backup 2500, Level 1 [(1) Put this card from your hand into your waiting room] (Choose 1 of your characters that is being frontal attacked, and that character gets +2500 power until end of turn)";
    public string AT_WX02_A06_Explanation = "【CONT】 Assist All of your characters in front of this card get +X power. X is equal to that character's level ×500.";
    public string AT_WX02_A07_Explanation = "Search your deck for up to 1 《Ooo》 character, reveal it to your opponent, put it into your hand, and shuffle your deck.";
    public string AT_WX02_A08_Explanation = "【CONT】 All of your characters get +1000 power and +1 soul. During this turn, when the next damage dealt by the attacking character that triggered this card is canceled, deal 1 damage to your opponent)";
    public string AT_WX02_A09_Explanation = "【ACT】 Brainstorm [(1) 【REST】 this card] Flip over 4 cards from the top of your deck, and put them into your waiting room. For each climax revealed among those cards, draw up to 1 card.";
    public string AT_WX02_A10_Explanation = "【AUTO】 Bond/[Marceline: Party Crasher] [(1)] (When this card is played and placed on stage, you may pay the cost. If you do, choose 1 [Marceline: Party Crasher] in your waiting room, and return it to your hand)";
    public string AT_WX02_A11_Explanation = "【CONT】 Assist All of your characters in front of this card get +500 power.";
    public string AT_WX02_A12_Explanation = "【CONT】 This card gets +500 power for each of your other 《Ooo》 characters.";
    public string AT_WX02_A13_Explanation = "【CONT】 All of your characters get +1000 power and +1 soul. When this card triggers, you may choose 1 character in your waiting room, and return it to your hand)";
    public string AT_WX02_A01_CardNo = "AT_WX02_A01";
    public string AT_WX02_A02_CardNo = "AT_WX02_A02";
    public string AT_WX02_A03_CardNo = "AT_WX02_A03";
    public string AT_WX02_A04_CardNo = "AT_WX02_A04";
    public string AT_WX02_A05_CardNo = "AT_WX02_A05";
    public string AT_WX02_A06_CardNo = "AT_WX02_A06";
    public string AT_WX02_A07_CardNo = "AT_WX02_A07";
    public string AT_WX02_A08_CardNo = "AT_WX02_A08";
    public string AT_WX02_A09_CardNo = "AT_WX02_A09";
    public string AT_WX02_A10_CardNo = "AT_WX02_A10";
    public string AT_WX02_A11_CardNo = "AT_WX02_A11";
    public string AT_WX02_A12_CardNo = "AT_WX02_A12";
    public string AT_WX02_A13_CardNo = "AT_WX02_A13";
    public string AT_WX02_A12_NAME = "Marceline: Party Crasher";

    public StringValues() 
    {
        switch (paramater)
        {
            case EnumController.Language.Japanese:
                OKDialog_Clock = japanese.OKDialog_Clock;
                OKDialog_Marigan = japanese.OKDialog_Marigan;
                HandOverDialog = japanese.HandOverDialog;
                YesOrNoDialog_CLIMAX_PHASE = japanese.YesOrNoDialog_CLIMAX_PHASE;
                YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = japanese.YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
                break;
            default:
                break;
        }
    }

    public class Japanese
    {
        public string OKDialog_Clock = "クロックするカードを選択してください";
        public string OKDialog_Marigan = "マリガンするカードを選択してください";
        public string HandOverDialog = "手札が7枚になるように捨ててください";
        public string YesOrNoDialog_CLIMAX_PHASE = "クライマックスフェイズに移動しますか";
        public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = "次の能力を使用しますか。:" + "【起】 集中 ［(1) このカードを【レスト】する］ あなたは自分の山札の上から4枚をめくり、控え室に置く。それらのカードのクライマックス1枚につき、あなたは1枚まで引く。";
    }

    public string YesOrNoDialog_ENCORE_CONFIRM(string paramater1)
    {
        return paramater1 + "をアンコールしますか";
    }

    public string YesOrNoDialog_COST_CONFIRM_HAND_TO_FIELD(int paramater1)
    {
        return "このカードをプレイするにはコスト'" + paramater1 + "'必要です";
    }

    public string YesOrNoDialog_COST_CONFIRM_BOND_FOR_HAND_TO_FIELD(string paramater1, int paramater2)
    {
        return "次の能力を使用しますか。:" + "【自】 絆／「" + paramater1 + "」 ［(" + paramater2 + ")］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「" + paramater1 + "」を1枚選び、手札に戻す）";
    }
}
