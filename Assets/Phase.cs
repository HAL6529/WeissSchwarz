using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;

public class Phase : MonoBehaviour
{
    [SerializeField] PhaseText phaseText;
    [SerializeField] Text text;
    [SerializeField] GameObject Panel;
    bool isAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationStart(EnumController.Turn phase)
    {
        Panel.SetActive(true);
        switch (phase){
            case EnumController.Turn.Player1_Draw:
                text.text = "Draw";
                break;
            case EnumController.Turn.Player1_Clock:
                text.text = "Clock";
                break;
            case EnumController.Turn.Player1_Main:
                text.text = "Main";
                break;
            case EnumController.Turn.Player1_Climax:
                text.text = "Climax";
                break;
            case EnumController.Turn.Player1_Attack:
                text.text = "Attack";
                break;
            case EnumController.Turn.Player1_Counter:
                text.text = "Counter";
                break;
            case EnumController.Turn.Player1_Encore:
                text.text = "Encore";
                break;
            case EnumController.Turn.Player2_Draw:
                text.text = "Draw";
                break;
            case EnumController.Turn.Player2_Clock:
                text.text = "Clock";
                break;
            case EnumController.Turn.Player2_Main:
                text.text = "Main";
                break;
            case EnumController.Turn.Player2_Climax:
                text.text = "Climax";
                break;
            case EnumController.Turn.Player2_Attack:
                text.text = "Attack";
                break;
            case EnumController.Turn.Player2_Counter:
                text.text = "Counter";
                break;
            case EnumController.Turn.Player2_Encore:
                text.text = "Encore";
                break;
            default:
                text.text = "Error";
                break;
        }
        isAnimation = true;
    }

    public void AnimationEnd()
    {
        Debug.Log("�Ă΂ꂽ");
        Panel.SetActive(false);
        phaseText.enabled = false;
        //isAnimation = false;
        //Panel.SetActive(false);
    }
}
