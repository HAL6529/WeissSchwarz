using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DummyHandCardUtil : MonoBehaviour
{
    [SerializeField] RectTransform m_rectTransform;
    [SerializeField] RectTransform m_canvasRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var magnification = m_canvasRectTransform.sizeDelta.x / Screen.width;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x = mousePosition.x * magnification - m_canvasRectTransform.sizeDelta.x / 2;
        mousePosition.y = mousePosition.y * magnification - m_canvasRectTransform.sizeDelta.y / 2;
        m_rectTransform.anchoredPosition = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.gameObject.SetActive(false);
        }
    }
}
