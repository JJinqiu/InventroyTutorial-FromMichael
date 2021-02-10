using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public Inventory myInventory;

    public void SaveGame()
    {
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath + "/game_SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");
        }

        var formatter = new BinaryFormatter(); // 二进制转化
        var file = File.Create(Application.persistentDataPath + "/game_SaveData/inventory.txt");

        var json = JsonUtility.ToJson(myInventory);

        formatter.Serialize(file, json);

        file.Close();
    }

    public void LoadGame()
    {
        var formatter = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/game_SaveData/inventory.txt"))
            return;
        var file = File.Open(Application.persistentDataPath + "/game_SaveData/inventory.txt", FileMode.Open);
        JsonUtility.FromJsonOverwrite((string) formatter.Deserialize(file), myInventory);
        file.Close();
    }
}