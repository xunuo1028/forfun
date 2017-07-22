using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForFunAC : MonoBehaviour {

    public Animator ac;
    public Animation currentA;
    private string cacheName = string.Empty;
    private int cacheType;

	// Use this for initialization
	void Start () {
        ac = this.transform.GetComponent<Animator>();
        //Play("Idle", 3);
        ac.SetBool("Idle", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play(string aName, int aType)
    {
        if(cacheName != "")
        {
            ac.SetBool(cacheName, false);
        }

        if (aType == 1)
        {
            //float
        }
        else if(aType == 2)
        {
            //int
        }
        else if(aType == 3)
        {
            ac.SetBool(aName, true);
        }
        else if(aType == 4)
        {
            ac.SetTrigger(aName);
        }

        cacheName = aName;
        cacheType = aType;
    }

    public void EndAnimation()
    {
        ac.SetBool(cacheName, false);
        ac.SetBool("Idle", true);
        cacheName = "Idle";
        cacheType = 3;
    }

    public void ChangeAnimation(string animationName, int aType)
    {

    }
}
