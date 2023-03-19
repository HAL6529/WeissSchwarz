using System.Collections;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class CardControllerTest : StrixBehaviour
{
    [SerializeField] private CardTest m_CardTest;
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
    [StrixRpc]
    public void sendMessage()
    {
        m_CardTest.AddNum();
    }

    public void onClicked()
    {
        RpcToAll(nameof(sendMessage));
    }
}
