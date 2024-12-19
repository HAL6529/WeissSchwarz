using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CreateDeckButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] Sprite deckcase;
    [SerializeField] Sprite deckcase2;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = deckcase2;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = deckcase;
    }
}
