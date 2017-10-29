using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelfGame
{
    public class TotalManager : MonoBehaviour
    {

        public static TotalManager Instance;

        public AnimationManager animationManager = new AnimationManager();

        // Use this for initialization
        void Start()
        {
            Instance = this;

            animationManager.Init();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

