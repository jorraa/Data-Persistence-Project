using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour {
    public GameObject prefab;
    private List<SaveManager.HighScore> highScores;
    void Start() {
        highScores = SaveManager.Instance.CurrentSaveData.highScores;
        Populate();
    }

    void Populate() {
        GameObject newObj;
        
        highScores.ForEach(highScore => {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<TextMeshProUGUI>().text = 
                "  " + highScore.score + " - " + highScore.playerName;
        });
    }
}
