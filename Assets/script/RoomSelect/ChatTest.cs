using System.Collections;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ChatTest : StrixBehaviour
{
    /// <summary>
    /// �`���b�g���̓E�B���h�E
    /// <summary>
    [SerializeField] private InputField inputField;

    [SerializeField] private TextBox m_TextBox;

    /// <summary>
    /// �`���b�g�\���E�B���h�E
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
    /// �e�L�X�g�𑗐M����
    /// </summary>
    /// <param name="message">���M���b�Z�[�W</param>
    [StrixRpc]
    public void sendMessage(string message)
    {
        m_TextBox.updateMessage(message);
    }

    /// <summary>
    /// ���M�{�^�����������ۂ̏���
    /// </summary>
    public void onclicked()
    {
        RpcToAll(nameof(sendMessage), inputField.text);
        inputField.text = "";
    }
}
