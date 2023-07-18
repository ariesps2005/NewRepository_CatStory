using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CatStory
{
    public class DataPersistenceManager : MonoBehaviour
    {

        [Header("File Storage Config")]
        [SerializeField]
        private string fileName;
        
        private GameData gameData;

        private List<IDataPersistence> dataPersistenceObjects;

        private FileDataHandler dataHandler;


        public static DataPersistenceManager instance { get; private set; }

        private void Awake()
        {

            Debug.Log(Application.persistentDataPath);

            if (instance != null)
            {
                Debug.LogError("Found more than one DataPersistenceManager in the project");
            }

            instance = this;
        }

        private void Start()
        {
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }


        //----------New, Load and Save functions-----------

        public void NewGame()
        {
            this.gameData = new GameData();
        }

        public void LoadGame()
        {
            //load gameData via FileDataHandler

            this.gameData = dataHandler.Load();

            //check if there is no data

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
                dataPersistenceObject.SaveData(ref gameData);
            }

            Debug.Log("Saved death count = " + gameData.deathCount);



            // save gameData to a JSON file via FileDataHandler
            dataHandler.Save(gameData);

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
