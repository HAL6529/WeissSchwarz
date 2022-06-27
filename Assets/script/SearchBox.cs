using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBox : MonoBehaviour
{
    [SerializeField] CardInfoManager m_cardInfoManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onButton()
    {
        string searchWord = GetComponent<InputField>().text;
        m_cardInfoManager.GetComponent<CardInfoManager>().Search(searchWord);
    }
}
