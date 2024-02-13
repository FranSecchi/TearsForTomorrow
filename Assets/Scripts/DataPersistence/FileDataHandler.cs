using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;


public class FileDataHandler
{
    private string dataDirPath = "";

    public FileDataHandler(string dataDirPath)
    {
        this.dataDirPath = dataDirPath;
    }

    public GameData Load(string fileName) 
    {
        string fullPath = Path.Combine(dataDirPath, fileName);
        GameData loadData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string json = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }
                }
                loadData = JsonConvert.DeserializeObject<GameData>(json);
            }
            catch (Exception e)
            {
                Debug.LogError("Error trying to save data to file: " + fullPath + "\n" + e);
            }
        }
        return loadData;
    }


    public void Save(GameData gameData, string fileName)
    {
        string fullPath = Path.Combine(dataDirPath, fileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));


            var json = JsonConvert.SerializeObject(gameData, Formatting.Indented);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(json);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error trying to save data to file: " + fullPath + "\n" + e);
        }
    }
}