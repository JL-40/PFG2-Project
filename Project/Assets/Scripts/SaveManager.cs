using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    string path;
    byte[] keys = new byte[] {0x42, 0x69, 0x15, 0x12 };

    void Start()
    {
        path = Application.dataPath + "/Save";
    }

    public void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);

        byte[] plainTxt = System.Text.Encoding.UTF8.GetBytes(json);
        byte[] XORTxt = new byte[plainTxt.Length];

        for (int i = 0; i < plainTxt.Length; i++)
        {
            XORTxt[i] = (byte)(plainTxt[i] ^ keys[i%keys.Length]);
        }
        File.WriteAllBytes(path + "/player.json", XORTxt);
    }

    public PlayerData LoadData()
    {
        string filepath = path + "/player.json";

        if (File.Exists(filepath))
        {
            byte[] rawRead = File.ReadAllBytes(filepath);
            byte[] decodeTxt = new byte[rawRead.Length];

            for (int i = 0; i < rawRead.Length; i++)
            {
                decodeTxt[i] = (byte)(rawRead[i] ^ keys[i%keys.Length]);
            }

            string json = System.Text.Encoding.UTF8.GetString(decodeTxt);

            Debug.Log(json);

            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            return null;
        }
    }
}
