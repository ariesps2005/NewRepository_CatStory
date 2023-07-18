using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CatStory
{
    public class FileDataHandler
    {


        private string dataDirPath = "";

        private string dataFileName = "";

        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
        }

        public GameData Load()
        {
            string fullPath = Path.Combine(dataDirPath, dataFileName);

            GameData loadedData = null;

            if (File.Exists(fullPath))
            {

                try
                {
                    
                    //load data from the file
                    string dataToLoad = "";

                    using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad= reader.ReadToEnd();
                        }
                    }

                    //deserialize the data from JSON

                    loadedData = JsonUtility.FromJson<GameData>(dataToLoad);


                }
                catch(Exception ex)
                {
                    Debug.LogError("Error occured when trying to load data from file" + fullPath + "\n" + ex);
                }



            }
            return loadedData;



        }

        public void Save(GameData data)
        {
            string fullPath = Path.Combine(dataDirPath, dataFileName);

            try
            {

                //create the directory the file will be written to if doesn't exist
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                //serialize the C# game data into JSON file

                string dataToStore = JsonUtility.ToJson(data, true);

                //write the file
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }

            }
            catch (Exception ex) 
            { Debug.LogError("Error occured when trying to save data to file" + fullPath + "\n" + ex); }

        } 
    }
}
