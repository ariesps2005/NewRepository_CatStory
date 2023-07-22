using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{

    public class GameEventsManager : MonoBehaviour
    {

        [SerializeField]
        private LifeManager _lifeManager;


        private int _deathCounter;
        public static GameEventsManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null) { Debug.LogError("Found more than one Game Events Manager in the scene"); }
            instance= this;
        }

        public event Action onPlayerDeath;

        public void PlayerDeath()
        {
            if (_deathCounter > 0) return;

            if (onPlayerDeath != null) 
            {
                _deathCounter++;
                onPlayerDeath(); 
            }
        }

        





    }
}
