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
            case EnumController.Turn.Draw:
                text.text = "Draw";
                break;
            case EnumController.Turn.Clock:
                text.text = "Clock";
                break;
            case EnumController.Turn.Main:
                text.text = "Main";
                break;
            case EnumController.Turn.Climax:
                text.text = "Climax";
                break;
            case EnumController.Turn.Attack:
                text.text = "Attack";
                break;
            case EnumController.Turn.Counter:
                text.text = "Counter";
                break;
            case EnumController.Turn.Encore:
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
            case EnumController.Turn.Draw:
                break;
            case EnumController.Turn.Clock:
                break;
            case EnumController.Turn.Main:
                break;
            case EnumController.Turn.Climax:
                break;
            case EnumController.Turn.Attack:
                break;
            case EnumController.Turn.Counter:
                break;
            case EnumController.Turn.Encore:
                break;
            default:
                break;
        }
    }
}
