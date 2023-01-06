using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseText : MonoBehaviour
{
    [SerializeField] Phase phase;
    // Start is called before the first frame update
    void Start()
    {
        phase.AnimationEnd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
