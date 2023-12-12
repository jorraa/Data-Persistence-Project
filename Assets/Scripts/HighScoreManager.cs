using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private void Start() {
        string currentPlayer = SaveManager.Instance.CurrentPlayer;
        if (currentPlayer != null && currentPlayer.Length > 0) {
            GameObject.Find("ToGameButton").SetActive(true);
        }
        else {
            GameObject.Find("ToGameButton").SetActive(false);
        }
        
    }

    private void PopulateList() {
        List<SaveManager.HighScore> highSCores = SaveManager.Instance.CurrentSaveData.highScores;
        GameObject rowText = GameObject.Find("RowText");
        
        GameObject go1 = Instantiate(rowText);
        Component textComponent = go1.GetComponent<Text>();
        
        

    }
    public void ToMenu() {
        SceneManager.LoadScene(0);
    }
    
    public void ToGame() {
        SceneManager.LoadScene(1);
    }
    
}
