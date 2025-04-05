using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringValues
{
    private EnumController.Language paramater = EnumController.Language.Japanese;

    Japanese japanese = new Japanese();

    public string OKDialog_Clock;
    public string OKDialog_Marigan;
    public string OKDialog_Counter;
    public string OKDialog_Counter_Confirm_Use_Card;
    public string OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM;
    public string HandOverDialog;
    public string YesOrNoDialog_CONFIRM_USE_COUNTER;
    public string YesOrNoDialog_CONFIRM_POOL_TRIGGER;
    public string YesOrNoDialog_CLIMAX_PHASE;
    public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_01T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_02T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_04T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_05T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_10T;
    public string YesOrNoDialog_COST_CONFIRM_DC_W01_13T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_03T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_05T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_09T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_14T;
    public string YesOrNoDialog_COST_CONFIRM_LB_W02_17T;
    public string YesOrNoDialog_COST_CONFIRM_SEND_MEMORY;
    public string SearchDialog_SearchMessage;
    public string ConfirmSearchOrSulvageCardDialog_Search;
    public string ConfirmSearchOrSulvageCardDialog_Sulvage;
    public string ConfirmSearchOrSulvageCardDialog_Clock_Sulvage;
    public string ConfirmSearchOrSulvageCardDialog_DC_W01_12T;
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
    public string DC_W01_01T_Explanation;
    public string DC_W01_02T_Explanation;
    public string DC_W01_03T_Explanation;
    public string DC_W01_04T_Explanation;
    public string DC_W01_05T_Explanation;
    public string DC_W01_06T_Explanation;
    public string DC_W01_07T_Explanation;
    public string DC_W01_08T_Explanation;
    public string DC_W01_09T_Explanation;
    public string DC_W01_10T_Explanation;
    public string DC_W01_11T_Explanation;
    public string DC_W01_12T_Explanation;
    public string DC_W01_13T_Explanation;
    public string DC_W01_14T_Explanation;
    public string DC_W01_15T_Explanation;
    public string DC_W01_16T_Explanation;
    public string DC_W01_17T_Explanation;
    public string DC_W01_18T_Explanation;
    public string DC_W01_19T_Explanation;
    public string DC_W01_20T_Explanation;
    public string LB_W02_01T_Explanation;
    public string LB_W02_02T_Explanation;
    public string LB_W02_03T_Explanation;
    public string LB_W02_04T_Explanation;
    public string LB_W02_05T_Explanation;
    public string LB_W02_06T_Explanation;
    public string LB_W02_07T_Explanation;
    public string LB_W02_08T_Explanation;
    public string LB_W02_09T_Explanation;
    public string LB_W02_10T_Explanation;
    public string LB_W02_11T_Explanation;
    public string LB_W02_12T_Explanation;
    public string LB_W02_13T_Explanation;
    public string LB_W02_14T_Explanation;
    public string LB_W02_15T_Explanation;
    public string LB_W02_16T_Explanation;
    public string LB_W02_17T_Explanation;
    public string LB_W02_18T_Explanation;
    public string LB_W02_19T_Explanation;
    public string LB_W02_20T_Explanation;
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
    public string DC_W01_01T_CardNo = "DC_W01_01T";
    public string DC_W01_02T_CardNo = "DC_W01_02T";
    public string DC_W01_03T_CardNo = "DC_W01_03T";
    public string DC_W01_04T_CardNo = "DC_W01_04T";
    public string DC_W01_05T_CardNo = "DC_W01_05T";
    public string DC_W01_06T_CardNo = "DC_W01_06T";
    public string DC_W01_07T_CardNo = "DC_W01_07T";
    public string DC_W01_08T_CardNo = "DC_W01_08T";
    public string DC_W01_09T_CardNo = "DC_W01_09T";
    public string DC_W01_10T_CardNo = "DC_W01_10T";
    public string DC_W01_11T_CardNo = "DC_W01_11T";
    public string DC_W01_12T_CardNo = "DC_W01_12T";
    public string DC_W01_13T_CardNo = "DC_W01_13T";
    public string DC_W01_14T_CardNo = "DC_W01_14T";
    public string DC_W01_15T_CardNo = "DC_W01_15T";
    public string DC_W01_16T_CardNo = "DC_W01_16T";
    public string DC_W01_17T_CardNo = "DC_W01_17T";
    public string DC_W01_18T_CardNo = "DC_W01_18T";
    public string DC_W01_19T_CardNo = "DC_W01_19T";
    public string DC_W01_20T_CardNo = "DC_W01_20T";
    public string LB_W02_01T_CardNo = "LB_W02_01T";
    public string LB_W02_02T_CardNo = "LB_W02_02T";
    public string LB_W02_03T_CardNo = "LB_W02_03T";
    public string LB_W02_04T_CardNo = "LB_W02_04T";
    public string LB_W02_05T_CardNo = "LB_W02_05T";
    public string LB_W02_06T_CardNo = "LB_W02_06T";
    public string LB_W02_07T_CardNo = "LB_W02_07T";
    public string LB_W02_08T_CardNo = "LB_W02_08T";
    public string LB_W02_09T_CardNo = "LB_W02_09T";
    public string LB_W02_10T_CardNo = "LB_W02_10T";
    public string LB_W02_11T_CardNo = "LB_W02_11T";
    public string LB_W02_12T_CardNo = "LB_W02_12T";
    public string LB_W02_13T_CardNo = "LB_W02_13T";
    public string LB_W02_14T_CardNo = "LB_W02_14T";
    public string LB_W02_15T_CardNo = "LB_W02_15T";
    public string LB_W02_16T_CardNo = "LB_W02_16T";
    public string LB_W02_17T_CardNo = "LB_W02_17T";
    public string LB_W02_18T_CardNo = "LB_W02_18T";
    public string LB_W02_19T_CardNo = "LB_W02_19T";
    public string LB_W02_20T_CardNo = "LB_W02_20T";
    public string AT_WX02_A12_NAME = "Marceline: Party Crasher";
    public string DC_W01_10T_NAME = "ロボ美春";

    public StringValues() 
    {
        switch (paramater)
        {
            case EnumController.Language.Japanese:
                OKDialog_Clock = japanese.OKDialog_Clock;
                OKDialog_Marigan = japanese.OKDialog_Marigan;
                OKDialog_Counter = japanese.OKDialog_Counter;
                OKDialog_Counter_Confirm_Use_Card = japanese.OKDialog_Counter_Confirm_Use_Card;
                OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM = japanese.OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM;
                HandOverDialog = japanese.HandOverDialog;
                YesOrNoDialog_CONFIRM_USE_COUNTER = japanese.YesOrNoDialog_CONFIRM_USE_COUNTER;
                YesOrNoDialog_CONFIRM_POOL_TRIGGER = japanese.YesOrNoDialog_CONFIRM_POOL_TRIGGER;
                YesOrNoDialog_CLIMAX_PHASE = japanese.YesOrNoDialog_CLIMAX_PHASE;
                YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = japanese.YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW;
                YesOrNoDialog_COST_CONFIRM_DC_W01_01T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_01T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_02T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_02T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_04T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_04T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_05T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_05T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_10T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_10T;
                YesOrNoDialog_COST_CONFIRM_DC_W01_13T = japanese.YesOrNoDialog_COST_CONFIRM_DC_W01_13T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_03T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_03T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_05T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_05T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_09T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_09T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_14T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_14T;
                YesOrNoDialog_COST_CONFIRM_LB_W02_17T = japanese.YesOrNoDialog_COST_CONFIRM_LB_W02_17T;
                YesOrNoDialog_COST_CONFIRM_SEND_MEMORY = japanese.YesOrNoDialog_COST_CONFIRM_SEND_MEMORY;
                SearchDialog_SearchMessage = japanese.SearchDialog_SearchMessage;
                ConfirmSearchOrSulvageCardDialog_Search = japanese.ConfirmSearchOrSulvageCardDialog_Search;
                ConfirmSearchOrSulvageCardDialog_Sulvage = japanese.ConfirmSearchOrSulvageCardDialog_Sulvage;
                ConfirmSearchOrSulvageCardDialog_Clock_Sulvage = japanese.ConfirmSearchOrSulvageCardDialog_Clock_Sulvage;
                ConfirmSearchOrSulvageCardDialog_DC_W01_12T = japanese.ConfirmSearchOrSulvageCardDialog_DC_W01_12T;
                DC_W01_01T_Explanation = japanese.DC_W01_01T_Explanation;
                DC_W01_02T_Explanation = japanese.DC_W01_02T_Explanation;
                DC_W01_03T_Explanation = japanese.DC_W01_03T_Explanation;
                DC_W01_04T_Explanation = japanese.DC_W01_04T_Explanation;
                DC_W01_05T_Explanation = japanese.DC_W01_05T_Explanation;
                DC_W01_06T_Explanation = japanese.DC_W01_06T_Explanation;
                DC_W01_07T_Explanation = japanese.DC_W01_07T_Explanation;
                DC_W01_08T_Explanation = japanese.DC_W01_08T_Explanation;
                DC_W01_09T_Explanation = japanese.DC_W01_09T_Explanation;
                DC_W01_10T_Explanation = japanese.DC_W01_10T_Explanation;
                DC_W01_11T_Explanation = japanese.DC_W01_11T_Explanation;
                DC_W01_12T_Explanation = japanese.DC_W01_12T_Explanation;
                DC_W01_13T_Explanation = japanese.DC_W01_13T_Explanation;
                DC_W01_14T_Explanation = japanese.DC_W01_14T_Explanation;
                DC_W01_15T_Explanation = japanese.DC_W01_15T_Explanation;
                DC_W01_16T_Explanation = japanese.DC_W01_16T_Explanation;
                DC_W01_17T_Explanation = japanese.DC_W01_17T_Explanation;
                DC_W01_18T_Explanation = japanese.DC_W01_18T_Explanation;
                DC_W01_19T_Explanation = japanese.DC_W01_19T_Explanation;
                DC_W01_20T_Explanation = japanese.DC_W01_20T_Explanation;
                LB_W02_01T_Explanation = japanese.LB_W02_01T_Explanation;
                LB_W02_02T_Explanation = japanese.LB_W02_02T_Explanation;
                LB_W02_03T_Explanation = japanese.LB_W02_03T_Explanation;
                LB_W02_04T_Explanation = japanese.LB_W02_04T_Explanation;
                LB_W02_05T_Explanation = japanese.LB_W02_05T_Explanation;
                LB_W02_06T_Explanation = japanese.LB_W02_06T_Explanation;
                LB_W02_07T_Explanation = japanese.LB_W02_07T_Explanation;
                LB_W02_08T_Explanation = japanese.LB_W02_08T_Explanation;
                LB_W02_09T_Explanation = japanese.LB_W02_09T_Explanation;
                LB_W02_10T_Explanation = japanese.LB_W02_10T_Explanation;
                LB_W02_11T_Explanation = japanese.LB_W02_11T_Explanation;
                LB_W02_12T_Explanation = japanese.LB_W02_12T_Explanation;
                LB_W02_13T_Explanation = japanese.LB_W02_13T_Explanation;
                LB_W02_14T_Explanation = japanese.LB_W02_14T_Explanation;
                LB_W02_15T_Explanation = japanese.LB_W02_15T_Explanation;
                LB_W02_16T_Explanation = japanese.LB_W02_16T_Explanation;
                LB_W02_17T_Explanation = japanese.LB_W02_17T_Explanation;
                LB_W02_18T_Explanation = japanese.LB_W02_18T_Explanation;
                LB_W02_19T_Explanation = japanese.LB_W02_19T_Explanation;
                LB_W02_20T_Explanation = japanese.LB_W02_20T_Explanation;
                break;
            default:
                break;
        }
    }

    public class Japanese
    {
        public string OKDialog_Clock = "クロックするカードを選択してください";
        public string OKDialog_Marigan = "マリガンするカードを選択してください";
        public string OKDialog_Counter = "カウンターカードがありません。";
        public string OKDialog_Counter_Confirm_Use_Card = "使用するカードを選択してください";
        public string OKDialog_HAND_ENCORE_SELECT_DISCARD_CONFIRM = "手札アンコールをします。捨てるカードを選んでください。";
        public string HandOverDialog = "手札が7枚になるように捨ててください";
        public string YesOrNoDialog_CONFIRM_USE_COUNTER = "手札の助太刀カードを使用しますか";
        public string YesOrNoDialog_CLIMAX_PHASE = "クライマックスフェイズに移動しますか";
        public string YesOrNoDialog_COST_CONFIRM_BRAIN_STORM_FOR_DRAW = "次の能力を使用しますか。:" + "【起】 集中 ［(1) このカードを【レスト】する］ あなたは自分の山札の上から4枚をめくり、控え室に置く。それらのカードのクライマックス1枚につき、あなたは1枚まで引く。";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_01T = "次の能力を使用しますか。:" + "【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_02T = "次の能力を使用しますか。:" + "【自】 このカードがアタックした時、クライマックス置場に「結婚式の歌姫」があるなら、あなたは自分の山札を上から1枚選び、ストック置場に置き、そのターン中、このカードのパワーを＋3000。";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_04T = "次の能力を使用しますか。:" + "【起】［(1)］ そのターン中、このカードのパワーを＋2000。";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_05T = "次の能力を使用しますか。:" + "【起】［(1)］ あなたは相手の前列のキャラを1枚選び、そのターン中、パワーを－1000。";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_10T = "次の能力を使用しますか。:" + "【自】［(1)］ このカードがアタックした時、クライマックス置場に「美春のオルゴール」があるなら、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。";
        public string YesOrNoDialog_COST_CONFIRM_DC_W01_13T = "次の能力を使用しますか。:" + "【起】［(2) このカードを【レスト】する］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_03T = "次の能力を使用しますか。:" + "このカードがアタックした時、クライマックス置場に「そよ風のハミング」があるなら、あなたは自分の山札を上から1枚選び、ストック置場に置き、そのターン中、このカードのパワーを＋3000。";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_05T = "次の能力を使用しますか。:" + "【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_09T = "次の能力を使用しますか。:" + "【起】［(1)］ あなたは相手のキャラを1枚選び、そのターン中、パワーを－500。";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_14T = "次の能力を使用しますか。:" + "【起】［(2)］このカードを【レスト】する］ あなたは自分のクロックを上から1枚選び、控え室に置く。";
        public string YesOrNoDialog_COST_CONFIRM_LB_W02_17T = "次の能力を使用しますか。:" + "【起】［(1)］ あなたは《動物》の自分のキャラを1枚選び、そのターン中、パワーを＋500。";
        public string YesOrNoDialog_COST_CONFIRM_SEND_MEMORY = "次の能力を使用しますか。:" + "【起】［(1)］ このカードを思い出にする。";
        public string YesOrNoDialog_CONFIRM_POOL_TRIGGER = "プールアイコンがトリガーしました。デッキトップをストックに置きますか。";
        public string SearchDialog_SearchMessage = "手札に加えるカードを選択してください";
        public string ConfirmSearchOrSulvageCardDialog_Search = "相手がカードを山札から加えようとしています";
        public string ConfirmSearchOrSulvageCardDialog_Sulvage = "相手がカードを控室から加えようとしています";
        public string ConfirmSearchOrSulvageCardDialog_Clock_Sulvage = "相手がカードをクロックから加えようとしています";
        public string ConfirmSearchOrSulvageCardDialog_DC_W01_12T = "相手がカードを控室から加えようとしています";
        public string DC_W01_01T_Explanation = "【起】［このカードを【レスト】する］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。";
        public string DC_W01_02T_Explanation = "【永】 大活躍【自】 このカードがプレイされて舞台に置かれた時、あなたは相手の手札を見る。【自】 このカードがアタックした時、クライマックス置場に「結婚式の歌姫」があるなら、あなたは自分の山札を上から1枚選び、ストック置場に置き、そのターン中、このカードのパワーを＋3000。";
        public string DC_W01_03T_Explanation = "あなたは自分の山札を上から1枚選び、ストック置場に置く。あなたは自分のキャラを1枚選び、そのターン中、パワーを＋500。";
        public string DC_W01_04T_Explanation = "【起】［(1)］ そのターン中、このカードのパワーを＋2000。";
        public string DC_W01_05T_Explanation = "【起】［(1)］ あなたは相手の前列のキャラを1枚選び、そのターン中、パワーを－1000。";
        public string DC_W01_06T_Explanation = "【永】 あなたのキャラすべてに、パワーを＋1000し、ソウルを＋1。";
        public string DC_W01_07T_Explanation = "【自】 他のバトルしているあなたのキャラが【リバース】した時、あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1000。【起】［(3)］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。";
        public string DC_W01_08T_Explanation = "【永】 アラーム このカードがクロックの1番上にあり、あなたのレベルが2以上なら、赤のあなたのキャラすべてに、次の能力を与える。『【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルがこのカードのレベル以下なら、あなたはそのキャラを【リバース】してよい。』";
        public string DC_W01_09T_Explanation = "【永】 他のあなたのカード名に「美春」を含むキャラすべてに、パワーを＋500。【自】 絆／「ロボ美春」 ［(1)］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「ロボ美春」を1枚選び、手札に戻す）";
        public string DC_W01_10T_Explanation = "【自】 このカードとバトルしているキャラが【リバース】した時、あなたはそのキャラを山札の上に置いてよい。【自】［(1)］ このカードがアタックした時、クライマックス置場に「美春のオルゴール」があるなら、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室のキャラを1枚選び、手札に戻す。";
        public string DC_W01_11T_Explanation = "";
        public string DC_W01_12T_Explanation = "あなたは自分の控え室のキャラを2枚まで選び、手札に戻す。";
        public string DC_W01_13T_Explanation = "【永】 他の《バナナ》のあなたのキャラがいるなら、このカードのパワーを＋1500。【起】［(2) このカードを【レスト】する］ あなたは自分の控え室のキャラを1枚選び、手札に戻す。";
        public string DC_W01_14T_Explanation = "";
        public string DC_W01_15T_Explanation = "";
        public string DC_W01_16T_Explanation = "【永】 他の《音楽》のあなたのキャラが2枚以上いるなら、このカードのパワーを＋1000。【自】 このカードが【リバース】した時、このカードとバトルしているキャラのレベルが1以下なら、あなたはそのキャラを【リバース】してよい。";
        public string DC_W01_17T_Explanation = "【起】【カウンター】 助太刀3000 レベル2 ［(1) 手札のこのカードを控え室に置く］ （あなたはフロントアタックされている自分のキャラを1枚選び、そのターン中、パワーを＋3000）";
        public string DC_W01_18T_Explanation = "あなたはレベル1以下の相手のキャラを1枚選び、控え室に置く。";
        public string DC_W01_19T_Explanation = "【永】 あなたのキャラすべてに、パワーを＋1000し、ソウルを＋1。（このカードがトリガーした時、あなたは自分の控え室のキャラを1枚選び、手札に戻してよい）";
        public string DC_W01_20T_Explanation = "【永】 あなたのキャラすべてに、ソウルを＋2。";
        public string LB_W02_01T_Explanation = "";
        public string LB_W02_02T_Explanation = "【起】［(1)］ あなたは自分のキャラを1枚選び、そのターン中、パワーを＋1500。【起】［(1)］ このカードを思い出にする。";
        public string LB_W02_03T_Explanation = "【永】 大活躍【自】 このカードがアタックした時、クライマックス置場に「そよ風のハミング」があるなら、あなたは自分の山札を上から1枚選び、ストック置場に置き、そのターン中、このカードのパワーを＋3000。【自】 アンコール ［手札のキャラを1枚控え室に置く］ （このカードが舞台から控え室に置かれた時、あなたはコストを払ってよい。そうしたら、このカードがいた枠に【レスト】して置く）";
        public string LB_W02_04T_Explanation = "【カウンター】 あなたは自分のキャラを2枚まで選び、そのターン中、パワーを＋1000。";
        public string LB_W02_05T_Explanation = "【永】 応援 このカードの前のあなたのキャラすべてに、パワーを＋500。【起】［(1)］ 他のあなたのキャラすべてに、そのターン中、《動物》を与える。";
        public string LB_W02_06T_Explanation = "";
        public string LB_W02_07T_Explanation = "【永】 他のあなたの「“最強の男児”謙吾」すべてに、パワーを＋1000。【起】【カウンター】 助太刀2000 レベル1 ［(1) 手札のこのカードを控え室に置く］ （あなたはフロントアタックされている自分のキャラを1枚選び、そのターン中、パワーを＋2000）";
        public string LB_W02_08T_Explanation = "【自】 このカードがプレイされて舞台に置かれた時、あなたは自分の山札を上から1枚選び、このカードの下にマーカーとして置く。【起】［このカードを【レスト】する］ このカードの下のマーカーが1枚以下なら、あなたは自分の山札を上から1枚選び、このカードの下にマーカーとして置く。【起】［このカードを【レスト】する］ そのターン中、あなたが自分の緑のキャラの能力を使う時、このカードの下のマーカーを、ストックのかわりに払ってよい。";
        public string LB_W02_09T_Explanation = "【起】［(1)］ あなたは相手のキャラを1枚選び、そのターン中、パワーを－500。";
        public string LB_W02_10T_Explanation = "【永】 あなたのキャラすべてに、パワーを＋1000し、ソウルを＋1。（このカードがトリガーした時、あなたは自分の山札を上から1枚選び、ストック置場に置いてよい）";
        public string LB_W02_11T_Explanation = "【永】 あなたのキャラすべてに、ソウルを＋2。";
        public string LB_W02_12T_Explanation = "あなたは自分の山札を見て《動物》のキャラを1枚まで選んで相手に見せ、手札に加える。その山札をシャッフルする。";
        public string LB_W02_13T_Explanation = "【自】［このカードを控え室に置く］ 他のあなたのキャラが舞台から控え室に置かれた時、後列にこのカードがいるなら、あなたはコストを払ってよい。そうしたら、そのカードをそのカードがいた枠に【レスト】して置く。";
        public string LB_W02_14T_Explanation = "【自】 あなたがレベルアップした時、あなたは自分の山札を上から1枚選び、ストック置場に置く。【起】［(2) このカードを【レスト】する］ あなたは自分のクロックを上から1枚選び、控え室に置く。";
        public string LB_W02_15T_Explanation = "【永】 アラーム このカードがクロックの1番上にあるなら、青のあなたのキャラすべてに、『【自】 アンコール ［手札のキャラを1枚控え室に置く］』という能力を与える。";
        public string LB_W02_16T_Explanation = "あなたは自分のクロックを1枚選び、手札に戻す。このカードを思い出にする。";
        public string LB_W02_17T_Explanation = "【永】 応援 このカードの前のあなたのキャラすべてに、パワーを＋500。【起】［(1)］ あなたは《動物》の自分のキャラを1枚選び、そのターン中、パワーを＋500。";
        public string LB_W02_18T_Explanation = "";
        public string LB_W02_19T_Explanation = "【自】［(1)］ このカードとバトルしているレベル2以上のキャラが【リバース】した時、あなたはコストを払ってよい。そうしたら、あなたは1枚引く。";
        public string LB_W02_20T_Explanation = "【永】 あなたのキャラすべてに、パワーを＋1000し、ソウルを＋1。";
    }

    public string YesOrNoDialog_COST_CONFIRM_HAND_TO_FIELD(int paramater1)
    {
        return "このカードをプレイするにはコスト'" + paramater1 + "'必要です";
    }

    public string YesOrNoDialog_COST_CONFIRM_BOND_FOR_HAND_TO_FIELD(string paramater1, int paramater2)
    {
        return "次の能力を使用しますか。:" + "【自】 絆／「" + paramater1 + "」 ［(" + paramater2 + ")］ （このカードがプレイされて舞台に置かれた時、あなたはコストを払ってよい。そうしたら、あなたは自分の控え室の「" + paramater1 + "」を1枚選び、手札に戻す）";
    }

    public string YesOrNoDialog_CONFIRM_CARD_EFFECT(string paramater1)
    {
        return paramater1 + "のカードの効果を使用しますか";
    }

    public string YesOrNoDialog_EVENT_CONFIRM(string paramater1)
    {
        return paramater1 + "をプレイしますか";
    }
}
