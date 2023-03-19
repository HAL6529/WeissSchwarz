using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] InputField inputField;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// テキストウィンドウを更新する
    /// </summary>
    /// <param name="message">送信メッセージ</param>
    public void updateMessage(string message)
    {
        Debug.Log("message = " + message);
        text.text = message;
    }
}
