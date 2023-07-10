using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatStory
{
    public class SavePoint : MonoBehaviour
    {

        [SerializeField]
        private SpriteRenderer _defaultSpriteRenderer;

        [SerializeField]
        private Sprite _defaultSprite;
        [SerializeField]
        private Sprite _HL_Sprite;



        private void Start()
        {
            _defaultSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void HighlightSprite()
        {
            _defaultSpriteRenderer.sprite = _HL_Sprite;
                     
                      
        
        }

        public void DeactivateHighlightSprite()
        {
            _defaultSpriteRenderer.sprite = _defaultSprite;

        }

    }
}
