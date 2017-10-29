using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfGame
{
    public class AnimationManager
    {
        public enum ActionState
        {
            Idle = 0,
            Walk,
            Run,
            Jump
        }

        private static Queue<ActionState> stateQueue;

        public ActionState currentState;

        public ActionState lastState;

        public static Queue<ActionState> StateQueue
        {
            get { return stateQueue; }
        }

        public void Init(ActionState action = ActionState.Idle)
        {
            currentState = action;
        }

        public static void EnQueue()
        {

        }

        public static void DeQueue()
        {

        }
    }
}


