using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTest : MonoBehaviour
{
    private int num;

    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        text.text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNum()
    {
        Debug.Log("Ok");
        num++;
        text.text = num.ToString();
    }
}
