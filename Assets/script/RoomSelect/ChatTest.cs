using System.Collections;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ChatTest : StrixBehaviour
{
    /// <summary>
    /// チャット入力ウィンドウ
    /// <summary>
    [SerializeField] private InputField inputField;

    [SerializeField] private TextBox m_TextBox;

    /// <summary>
    /// チャット表示ウィンドウ
    /// <summary>
    //[SerializeField] private ChatPopupWindow chatWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// テキストを送信する
    /// </summary>
    /// <param name="message">送信メッセージ</param>
    [StrixRpc]
    public void sendMessage(string message)
    {
        m_TextBox.updateMessage(message);
    }

    /// <summary>
    /// 送信ボタンを押した際の処理
    /// </summary>
    public void onclicked()
    {
        RpcToAll(nameof(sendMessage), inputField.text);
        inputField.text = "";
    }
}
