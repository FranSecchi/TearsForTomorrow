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
                settings.Converters.Add(new PowerUPConverter()); // Add the custom converter
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
            settings.Converters.Add(new PowerUPConverter()); // Add the custom converter

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
public class PowerUPConverter : JsonConverter<PowerUP>
{
    public override PowerUP ReadJson(JsonReader reader, Type objectType, PowerUP existingValue, bool hasExistingValue, JsonSerializer serializer)
    {

        PowerUP powerUP = ScriptableObject.CreateInstance<PowerUP>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.EndObject)
                break;

            if (reader.TokenType == JsonToken.PropertyName)
            {
                string propertyName = (string)reader.Value;
                reader.Read();

                switch (propertyName)
                {
                    case "tier":
                        powerUP.tier = (PU_Tier)Enum.Parse(typeof(PU_Tier), (string)reader.Value);
                        break;
                    case "description":
                        powerUP.Description = (string)reader.Value;
                        break;
                    case "prize":
                        powerUP.Prize = (int)(long)reader.Value;
                        break;
                    case "artworkPath":
                        powerUP.artworkPath = (string)reader.Value;
                        break;
                    case "maxHealth":
                        powerUP.maxHealth = (float)(double)reader.Value;
                        break;
                    case "moveSpeed":
                        powerUP.moveSpeed = (float)(double)reader.Value;
                        break;
                    case "flying":
                        powerUP.flying = (bool)reader.Value;
                        break;
                    case "damage":
                        powerUP.damage = (int)(long)reader.Value;
                        break;
                    case "fireRate":
                        powerUP.fireRate = (float)(double)reader.Value;
                        break;
                    case "bulletSpeed":
                        powerUP.bulletSpeed = (float)(double)reader.Value;
                        break;
                    case "bulletSize":
                        powerUP.bulletSize = (float)(double)reader.Value;
                        break;
                    case "tripleShot":
                        powerUP.tripleShot = (bool)reader.Value;
                        break;
                    case "diagonalShot":
                        powerUP.diagonalShot = (bool)reader.Value;
                        break;
                    case "doubleShot":
                        powerUP.doubleShot = (bool)reader.Value;
                        break;
                    case "reloadDuringDash":
                        powerUP.reloadDuringDash = (int)(long)reader.Value;
                        break;
                    case "tempDashVelocity":
                        powerUP.tempDashVelocity = (float)(double)reader.Value;
                        break;
                    case "tempDashDuration":
                        powerUP.tempDashDuration = (float)(double)reader.Value;
                        break;
                    case "tempDashCooldown":
                        powerUP.tempDashCooldown = (float)(double)reader.Value;
                        break;
                    case "tempShield":
                        powerUP.tempShield = (int)(long)reader.Value;
                        break;
                    default:
                        Debug.LogWarning("Unknown property: " + propertyName);
                        break;
                }
            }
        }

        return powerUP;
    }


    public override void WriteJson(JsonWriter writer, PowerUP value, JsonSerializer serializer)
    {
        writer.WriteStartObject();

        writer.WritePropertyName("tier");
        writer.WriteValue(value.tier.ToString());

        writer.WritePropertyName("description");
        writer.WriteValue(value.Description);

        writer.WritePropertyName("prize");
        writer.WriteValue(value.Prize);

        writer.WritePropertyName("artworkPath");
        writer.WriteValue(value.artworkPath);

        writer.WritePropertyName("maxHealth");
        writer.WriteValue(value.maxHealth);

        writer.WritePropertyName("moveSpeed");
        writer.WriteValue(value.moveSpeed);

        writer.WritePropertyName("flying");
        writer.WriteValue(value.flying);

        writer.WritePropertyName("damage");
        writer.WriteValue(value.damage);

        writer.WritePropertyName("fireRate");
        writer.WriteValue(value.fireRate);

        writer.WritePropertyName("bulletSpeed");
        writer.WriteValue(value.bulletSpeed);

        writer.WritePropertyName("bulletSize");
        writer.WriteValue(value.bulletSize);

        writer.WritePropertyName("tripleShot");
        writer.WriteValue(value.tripleShot);

        writer.WritePropertyName("diagonalShot");
        writer.WriteValue(value.diagonalShot);

        writer.WritePropertyName("doubleShot");
        writer.WriteValue(value.doubleShot);

        writer.WritePropertyName("reloadDuringDash");
        writer.WriteValue(value.reloadDuringDash);

        writer.WritePropertyName("tempDashVelocity");
        writer.WriteValue(value.tempDashVelocity);

        writer.WritePropertyName("tempDashDuration");
        writer.WriteValue(value.tempDashDuration);

        writer.WritePropertyName("tempDashCooldown");
        writer.WriteValue(value.tempDashCooldown);

        writer.WritePropertyName("tempShield");
        writer.WriteValue(value.tempShield);

        writer.WriteEndObject();
    }

    public override bool CanWrite => true;

    public override bool CanRead => true;
}