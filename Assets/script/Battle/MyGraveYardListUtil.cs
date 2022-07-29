using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGraveYardListUtil : MonoBehaviour
{
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateSprite(BattleCardInfo m_battleCardInfo)
    {
        if (m_battleCardInfo == null)
        {
            this.gameObject.SetActive(false);
            return;
        }

        Sprite sprite = m_battleCardInfo.sprite;
        if (sprite != null)
        {
            image.sprite = sprite;
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
