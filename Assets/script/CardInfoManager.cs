using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoManager : MonoBehaviour
{
    public List<GameObject> searchCardList = new List<GameObject>();
    [SerializeField] InputField m_inputField;

    // Start is called before the first frame update
    void Start()
    {
        InitializeSearchCardList();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeSearchCardList()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            searchCardList.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
    }

    public void Search()
    {
        string searchWord = m_inputField.text;
        for (int i = 0; i < searchCardList.Count; i++)
        {
            searchCardList[i].GetComponent<CardInfoUtil>().isHitForKeyword(searchWord.Split(' '));
        }
    }
}
