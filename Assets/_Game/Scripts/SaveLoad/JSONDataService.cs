using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class JsonDataService : IDataService
{
    public void SaveData<T>(string relativePath, T data)
    {
        string path = Application.persistentDataPath + relativePath;

        try
        {
            if (File.Exists(path))
            {
                Debug.Log("Data exists. Deleting old file and writing a new one!");
                File.Delete(path);
            }
            else
            {
                Debug.Log("Writing file for the first time!");
            }

            using FileStream stream = File.Create(path);
            stream.Close();

            string json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(path, json);
        }

        catch (Exception exception)
        {
            Debug.LogError($"Unable to save data due to: {exception.Message} {exception.StackTrace}");
        }
    }

    public T LoadData<T>(string relativePath)
    {
        string path = Application.persistentDataPath + relativePath;

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}. File does not exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }

        try
        {
            string json = File.ReadAllText(path);
            T data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }
        catch (Exception exception)
        {
            Debug.LogError($"Failed to load data due to: {exception.Message} {exception.StackTrace}");
            throw;
        }
    }
}