using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseDialog : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Button MainPhaseButton;
    [SerializeField] Button ClimaxPhaseButton;
    [SerializeField] Button AttackPhaseButton;
    [SerializeField] Button EncorePhaseButton;

    [SerializeField] Image MainPhaseImage;
    [SerializeField] Image ClimaxPhaseImage;
    [SerializeField] Image AttackPhaseImage;
    [SerializeField] Image EncorePhaseImage;

    public void onCloseButton()
    {
        this.gameObject.SetActive(false);
    }

    public void Open()
    {
        if(m_GameManager.phase == EnumController.Turn.Main && m_GameManager.isTurnPlayer)
        {
            this.gameObject.SetActive(true);
            MainPhaseButton.interactable = false;
            ClimaxPhaseButton.interactable = true;
            AttackPhaseButton.interactable = true;
            EncorePhaseButton.interactable = true;

            MainPhaseImage.color = new Color(0, 145f / 255f, 1, 50f / 255f);
            ClimaxPhaseImage.color = ClimaxPhaseImage.color = new Color(160f / 255f, 0, 1, 1);
            AttackPhaseImage.color = new Color(1, 0, 1, 1);
            EncorePhaseImage.color = new Color(255f / 255f, 200f / 255f, 1, 1);
            return;
        }else if(m_GameManager.phase == EnumController.Turn.Climax && m_GameManager.isTurnPlayer)
        {
            this.gameObject.SetActive(true);
            MainPhaseButton.interactable = false;
            ClimaxPhaseButton.interactable = false;
            AttackPhaseButton.interactable = true;
            EncorePhaseButton.interactable = true;

            MainPhaseImage.color = new Color(0, 145f / 255f, 1, 50f / 255f);
            ClimaxPhaseImage.color = new Color(160f / 255f, 0, 1, 50f / 255f);
            AttackPhaseImage.color = new Color(1, 0, 1, 1);
            EncorePhaseImage.color = new Color(255f / 255f, 200f / 255f, 1, 1);
            return;
        }else if(m_GameManager.phase == EnumController.Turn.Attack && m_GameManager.isTurnPlayer)
        {
            this.gameObject.SetActive(true);
            MainPhaseButton.interactable = false;
            ClimaxPhaseButton.interactable = false;
            AttackPhaseButton.interactable = false;
            EncorePhaseButton.interactable = true;

            MainPhaseImage.color = new Color(0, 145f / 255f, 1, 50f / 255f);
            ClimaxPhaseImage.color = new Color(160f / 255f, 0, 1, 50f / 255f);
            AttackPhaseImage.color = new Color(1, 0, 1, 50f / 255f);
            EncorePhaseImage.color = new Color(255f / 255f, 200f / 255f, 1, 1);
            return;
        }
    }

    public void onClimaxButton()
    {
        this.gameObject.SetActive(false);
    }

    public void onAttackButton()
    {
        m_GameManager.SendAttackPhase();
        this.gameObject.SetActive(false);
    }

    public void onEncoreButton()
    {
        m_GameManager.SendEncorePhase();
        this.gameObject.SetActive(false);
    }

    public void OffDialog()
    {
        this.gameObject.SetActive(false);
    }
}
