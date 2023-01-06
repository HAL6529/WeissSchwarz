using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBasic : MonoBehaviour
{
    public bool isPlaying = false;
    public bool start = false;
    public bool goal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goal)
        {
            AnimationEnd();
            return;
        }
        if (start)
        {
            AnimationStart();
            return;
        }
    }

    void AnimationStart()
    {
        //Debug.Log("スタート");
        //start = false;
    }

    void AnimationEnd()
    {
        //Debug.Log("ゴール");
        //goal = false;
    }
}
