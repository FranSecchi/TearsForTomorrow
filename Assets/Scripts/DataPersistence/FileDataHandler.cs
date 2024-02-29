using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using Newtonsoft.Json.Linq;


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
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new Vector3Converter());
                loadData = JsonConvert.DeserializeObject<GameData>(json, settings);
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
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new Vector3Converter());

            var json = JsonConvert.SerializeObject(gameData, Formatting.Indented, settings);
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
public class Vector3Converter : JsonConverter<Vector3>
{
    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject)
        {
            JObject obj = JObject.Load(reader);
            float x = (float)obj["x"];
            float y = (float)obj["y"];
            float z = (float)obj["z"];
            return new Vector3(x, y, z);
        }

        throw new JsonReaderException("Unexpected token type for Vector3");

    }


    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("x");
        writer.WriteValue(value.x);
        writer.WritePropertyName("y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("z");
        writer.WriteValue(value.z);
        writer.WriteEndObject();
    }

    public override bool CanWrite => true;

    public override bool CanRead => true;
}