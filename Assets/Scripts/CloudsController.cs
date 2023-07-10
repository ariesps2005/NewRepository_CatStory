using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CatStory
{
    public class CloudsController : MonoBehaviour
    {


        [SerializeField]
        private GameObject _clouds;
        [SerializeField]
        private float _cloudsSpeed = 0.2f;

        // Update is called once per frame
        void Update()
        {
            _clouds.transform.Translate(Vector2.left * _cloudsSpeed * Time.deltaTime);
        }
    }
}
