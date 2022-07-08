using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumController;
using ExtendUtil;

public class DeckListPanelUtil : MonoBehaviour
{
    private Sprite sprite;
    [SerializeField] int index;
    [SerializeField] DeckListManager deckList;
    [SerializeField] filterDialog m_filterDialog;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInfo(Sprite sprite)
    {
        this.sprite = sprite;
        changeSprite();
    }

    private void changeSprite()
    {
        if(sprite == null)
        {
            this.gameObject.SetActive(false);
            this.gameObject.GetComponent<Image>().sprite = null;
            return;
        }
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<Image>().sprite = sprite;
    }

    public void onButton()
    {
        if (Input.GetMouseButtonUp(1))
        {
            m_filterDialog.closeFilter();
            // �E�N���b�N��
            deckList.removeCard(index);
        } else if (Input.GetMouseButtonUp(0))
        {
            m_filterDialog.closeFilter();
            // ���N���b�N��
            deckList.onShowInfo(index);
        }
    }
}
