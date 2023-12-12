using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
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
        public List<HighScore> highScores;
    }

    [System.Serializable]
    public class HighScore {
        public HighScore(string playerName, int score) {
            this.playerName = playerName;
            this.score = score;
        }
        public string playerName;
        public int score;
    }

    public static void CheckHighScores(string playerName, int score) {
        Debug.Log("Check: " + playerName + ": " + score);
        if (Instance.CurrentSaveData.highScores.Any(hScore => hScore.playerName == playerName)) {
            Instance.CurrentSaveData.highScores.ForEach(highScore => {
                if (playerName == highScore.playerName && score > highScore.score) {
                    highScore.score = score;
                    saveCurrentData();
                }
            });
        } else {
          Instance.CurrentSaveData.highScores.Add(new HighScore(playerName, score));
          saveCurrentData();
        }
    }

    private static void saveCurrentData() {
        string json = JsonUtility.ToJson(Instance.CurrentSaveData);
        File.WriteAllText(m_saveFilename, json);
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
