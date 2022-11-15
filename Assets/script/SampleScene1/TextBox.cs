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
    /// �e�L�X�g�E�B���h�E���X�V����
    /// </summary>
    /// <param name="message">���M���b�Z�[�W</param>
    public void updateMessage(string message)
    {
        Debug.Log("message = " + message);
        text.text = message;
    }
}
