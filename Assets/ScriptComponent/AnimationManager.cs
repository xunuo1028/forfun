using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager {

    private static AnimationManager instance;

    private static Queue<AnimationState> stateQueue;

    public static AnimationManager Instance
    {
        get { return instance; }
    }

    public static Queue<AnimationState> StateQueue
    {
        get{ return stateQueue; }
    }

    public void Init()
    {
        if (instance == null)
        {
            instance = new AnimationManager();
        }
    }
}

public class AnimationState
{
    private string stateName;
    private bool isRunning;

    public string StateName
    {
        get
        { 
            return stateName;
        }
    }

    public bool IsRunning
    {
        get
        {
            return isRunning;
        }
    }
}
