using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace CatStory
{
    public class DeathCount : MonoBehaviour, IDataPersistence
    {
        private int deathCount = 0;

        public TMP_Text deathCountText;

        private void Awake()
        {
            deathCountText = this.GetComponent<TMP_Text>();
            
        }

        // Start is called before the first frame update
        private void Start()
        {
            GameEventsManager.instance.onPlayerDeath += OnPlayerDeath;
        }

        private void OnDestroy()
        {
            GameEventsManager.instance.onPlayerDeath -= OnPlayerDeath;
        }


        // Update is called once per frame
        void Update()
        {
            deathCountText.text = "Death:" + deathCount;
        }

        public void OnPlayerDeath()
        {
            deathCount++;
        }

        public void LoadData(GameData data)
        {
            Debug.Log(data);
            this.deathCount = data.deathCount;
        }

        public void SaveData(GameData data)
        {
            Debug.Log(data);
            data.deathCount = this.deathCount;
        }

        
    }
}
