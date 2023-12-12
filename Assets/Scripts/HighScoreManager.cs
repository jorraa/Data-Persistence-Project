using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ToMenu() {
        SceneManager.LoadScene(0);
    }
    
    public void ToGame() {
        SceneManager.LoadScene(1);
    }
    
}
