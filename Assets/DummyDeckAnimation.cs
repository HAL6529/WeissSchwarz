using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityForge.AnimCallbacks;

public class DummyDeckAnimation : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private int layerIndex;
    [SerializeField] private string clipName;
    [SerializeField] GameObject DummyDrawObj;

    // Start is called before the first frame update
    void Start()
    {
        animator.AddClipStartCallback(layerIndex, clipName, () => print("ŠJŽn"));
        animator.AddClipCallback(layerIndex, clipName, 0.4f, () => AnimationEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationStart()
    {
        DummyDrawObj.SetActive(true);
        animator.Play("DrawAnimation", 0, 0);
    }

    public void AnimationEnd()
    {
        DummyDrawObj.SetActive(false);
    }
}
