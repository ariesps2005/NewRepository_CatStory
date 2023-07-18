using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class ToyMouseLive : MonoBehaviour
    {

        [SerializeField]
        private LifeManager _lives;

        public void OnTriggerEnter2D(Collider2D collision)
        {

            if (_lives.Lives <= 8)
            {
                FindObjectOfType<LifeManager>().GetLife();

                Destroy(gameObject);
            }


        }

    }
}
