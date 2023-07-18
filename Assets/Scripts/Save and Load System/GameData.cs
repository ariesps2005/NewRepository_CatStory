using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{

    [System.Serializable]
    public class GameData
    {

        public int deathCount;
        public Vector3 playerPosition;

        public GameData()
        {
            this.deathCount = 0;

            playerPosition = Vector3.zero;
        }



    }
}
