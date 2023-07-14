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
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            deathCountText.text = deathCountText.text + deathCount.ToString();
        }

        public void OnPlayerDeath()
        {
            deathCount++;
        }

        public void LoadData(GameData data)
        {
            this.deathCount = data.deathCount;
        }

        public void SaveData(ref GameData data)
        {
            data.deathCount = this.deathCount;
        }

        public void SaveData(GameData data) => throw new System.NotImplementedException();
    }
}
