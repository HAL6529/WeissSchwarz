using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using UnityForge.AnimCallbacks;

public class Phase : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PhaseText phaseText;
    [SerializeField] Text text;
    [SerializeField] GameObject Panel;
    EnumController.Turn phase;
    bool isAnimation = false;
    [SerializeField] private Animator animator;
    [SerializeField] private int layerIndex;
    [SerializeField] private string clipName;

    private void Start()
    {
        animator.AddClipStartCallback(layerIndex, clipName, () => print("�J�n"));
        //animator.AddClipEndCallback(layerIndex, clipName, () => AnimationEnd());
        animator.AddClipCallback(layerIndex, clipName, 2.5f, () => AnimationEnd());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimationStart(EnumController.Turn phase)
    {
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
        isAnimation = true;
        animator.Play("PhaseAnimation", 0, 0);
    }

    public void AnimationEnd()
    {
        print("�I��");
        Panel.SetActive(false);
    }
}