using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandCardUtil : MonoBehaviour
{
    public BattleCardInfo m_battleCardInfo;
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateSprite()
    {
        if(m_battleCardInfo == null || m_battleCardInfo.sprite == null)
        {
            this.gameObject.SetActive(false);
            return;
        }
        image.sprite = m_battleCardInfo.sprite;
        this.gameObject.SetActive(true);
    }
}
