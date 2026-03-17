using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoManager : MonoBehaviour
{
    public List<GameObject> searchCardList = new List<GameObject>();
    public List<ContentSizeFitter> ContentSizeFitterList = new List<ContentSizeFitter>();
    [SerializeField] InputField m_inputField;
    [SerializeField] SearchFilter m_searchFilter;
    [SerializeField] filterDialog m_filterDialog;

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
            GameObject obj = this.gameObject.transform.GetChild(i).gameObject;
            for (int n = 0; n < obj.transform.childCount; n++)
            {
                searchCardList.Add(obj.transform.GetChild(n).gameObject);
            }
        }
    }

    public void Search()
    {
        m_filterDialog.closeFilter();
        string searchWord = m_inputField.text;
        for (int i = 0; i < searchCardList.Count; i++)
        {
            searchCardList[i].GetComponent<CardInfoUtil>().isHitForKeyword(searchWord.Split(' '), m_searchFilter);
        }

        for(int i = 0; i < ContentSizeFitterList.Count; i++)
        {
            ContentSizeFitterList[i].SetLayoutHorizontal();
            ContentSizeFitterList[i].SetLayoutVertical();

            //レイアウトを即時更新
            LayoutRebuilder.ForceRebuildLayoutImmediate(ContentSizeFitterList[i].GetComponent<RectTransform>());
        }
    }
}
