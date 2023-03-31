using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    string path;

    void Start()
    {
        path = Application.dataPath + "/Save";
    }

    public void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path + "/player.json", json);
    }

    public PlayerData LoadData()
    {
        string filepath = path + "/player.json";

        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            return null;
        }
    }
}
