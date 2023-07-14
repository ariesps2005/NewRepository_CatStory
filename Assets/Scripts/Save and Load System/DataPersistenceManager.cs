using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CatStory
{
    public class DataPersistenceManager : MonoBehaviour
    {

        private GameData gameData;

        private List<IDataPersistence> dataPersistenceObjects;

        public static DataPersistenceManager instance { get; private set; }

        private void Awake()
        {

            if (instance != null)
            {
                Debug.LogError("Found more than one DataPersistenceManager in the project");
            }

            instance = this;
        }

        private void Start() => this.dataPersistenceObjects = FindAllDataPersistenceObjects();


        //----------New, Load and Save functions-----------

        public void NewGame()
        {
            this.gameData = new GameData();
        }

        public void LoadGame()
        {
            //to do - load gameData via FileDataHandler

            if (this.gameData != null)
            {
                Debug.Log("No data to load");
                NewGame();//temporarily
            }

            //to do - push the loaded data to scripts that need it

            foreach(IDataPersistence dataPersistenceObject in dataPersistenceObjects)
            {
                dataPersistenceObject.LoadData(gameData);
            }

            Debug.Log("Loaded death count = " + gameData.deathCount);


        }

        public void SaveGame()
        {
            // to do - pass the data to other scripts so they can update it

            foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
            {
                dataPersistenceObject.SaveData(gameData);
            }

            Debug.Log("Saved death count = " + gameData.deathCount);



            // to do - save gameData to a JSON file via FileDataHandler
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {

            IEnumerable<IDataPersistence> dataPersistenceObjects = 
                FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }














    }
}
