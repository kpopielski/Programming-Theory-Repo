using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string PlayerName;
    public string weight;
    public string age;
    public int type;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    [System.Serializable]
    class SaveData
    {
        
        public string weight;
        public string age;
        public int type;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        
        data.age = age;
        data.weight = weight;
        data.type = type;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            
            weight = data.weight;
            age = data.age;
            type = data.type;
        }
    }

}
