using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public string lastAnimationName = string.Empty;

    private Animator ac;

    void Start()
    {
        ac = this.GetComponent<Animator>();
    }
    

    public void RunAnimationBool(string name)
    {
        if(lastAnimationName != string.Empty)
        {
            ac.SetBool(lastAnimationName, false);
        }

        ac.SetBool(name, true);

        lastAnimationName = name;
    }

    public void SetIdle()
    {
        if (lastAnimationName != string.Empty)
        {
            ac.SetBool(lastAnimationName, false);
        }
    }
    
}


