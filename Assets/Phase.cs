using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using UnityForge.AnimCallbacks;

public class Phase : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Text text;
    [SerializeField] GameObject Panel;
    EnumController.Turn phase = EnumController.Turn.VOID;
    [SerializeField] private Animator animator;
    [SerializeField] private int layerIndex;
    [SerializeField] private string clipName;

    private void Start()
    {
        animator.AddClipStartCallback(layerIndex, clipName, () => print("äJén"));
        //animator.AddClipEndCallback(layerIndex, clipName, () => AnimationEnd());
        animator.AddClipCallback(layerIndex, clipName, 2.5f, () => AnimationEnd());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimationStart(EnumController.Turn phase)
    {
        gameManager.isAnimation = true;
        Panel.SetActive(true);
        this.phase = phase;

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
        animator.Play("PhaseAnimation", 0, 0);
    }

    public void AnimationEnd()
    {
        print("èIóπ");
        Panel.SetActive(false);
        gameManager.isAnimation = false ;
        switch (phase)
        {
            case EnumController.Turn.Player1_Draw:
                gameManager.DrawPhaseEnd();
                break;
            case EnumController.Turn.Player1_Clock:
                gameManager.ClockPhaseStart();
                break;
            case EnumController.Turn.Player1_Main:
                break;
            case EnumController.Turn.Player1_Climax:
                break;
            case EnumController.Turn.Player1_Attack:
                break;
            case EnumController.Turn.Player1_Counter:
                break;
            case EnumController.Turn.Player1_Encore:
                break;
            case EnumController.Turn.Player2_Draw:
                break;
            case EnumController.Turn.Player2_Clock:
                break;
            case EnumController.Turn.Player2_Main:
                break;
            case EnumController.Turn.Player2_Climax:
                break;
            case EnumController.Turn.Player2_Attack:
                break;
            case EnumController.Turn.Player2_Counter:
                break;
            case EnumController.Turn.Player2_Encore:
                break;
            default:
                break;
        }
    }
}
