using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{

    public void StartGame() {
        GameObject playerNameInput = GameObject.Find("PlayerNameInput");
        SaveManager.Instance.CurrentPlayer = playerNameInput.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void ShowHighScores() {
        GameObject playerNameInput = GameObject.Find("PlayerNameInput");
        SaveManager.Instance.CurrentPlayer = playerNameInput.GetComponent<TMP_InputField>().text;

        SceneManager.LoadScene(2);
    }
    public void Exit() {
        if (Application.isPlaying){
            EditorApplication.ExitPlaymode();
        }else{
            Application.Quit();
        }
    }

}
