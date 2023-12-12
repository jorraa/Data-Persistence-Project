using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance;
    public string CurrentPlayer;
    private static string m_saveFilename;
    public SaveData CurrentSaveData;

    private void Awake() {
        m_saveFilename = Application.persistentDataPath + "/savefile.json";
        if (Instance != null) {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    
    [System.Serializable]
    public class SaveData {
        public string highScorePlayer;
        public int highScore;
    }

    public static void SaveHighScore(string playerName, int highScore) {
        SaveData data = new SaveData();
        data.highScorePlayer = playerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(m_saveFilename, json);
    }
    
    public SaveData LoadData() {
        string path = m_saveFilename;
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            CurrentSaveData = data;
            return data;
        }
        return null;
    }
}
