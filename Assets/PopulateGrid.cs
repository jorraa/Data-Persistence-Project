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

    void Update()
    {
        
    }

    void Populate() {
        GameObject newObj;
        
        highScores.ForEach(highScore => {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<TextMeshProUGUI>().text = 
                "  " + highScore.score + " - " + highScore.playerName;
        });
        /*
        for (int i = 0; i < 10; i++) {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<TextMeshProUGUI>().text = "huhuu";
            Debug.Log("text" + newObj.GetComponent<TextMeshProUGUI>().text);
        }
        */
    }
}
