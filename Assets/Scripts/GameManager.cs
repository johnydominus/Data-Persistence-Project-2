using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public string highScoreName;
    public int highScoreValue;

    [System.Serializable]
    public class SaveData
    {
        public string highScoreName;
        public int highScoreValue;
    }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScoreValue = highScoreValue;

        string json = JsonUtility.ToJson(data);

        try
        {
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            Debug.Log("Successfully saved high score to " + Application.persistentDataPath + "/savefile.json");
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving high score: " + e.Message);
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreValue = data.highScoreValue;
            highScoreName = data.highScoreName;
        }
        else
        {
            highScoreName = string.Empty;
            highScoreValue = 0;
        }
        Debug.Log("High Score Loaded from " + Application.persistentDataPath + "/savefile.json");
    }
}
