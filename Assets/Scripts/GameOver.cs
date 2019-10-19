using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text score;
    public Text coins;
    public Text height;

    public int theScore;

    FallingController theFallingController;

    // Start is called before the first frame update
    void Start()
    {
        theFallingController = FindObjectOfType<FallingController>();
        height.text = "Height: " + (Mathf.Round(theFallingController.highestPoint+4) * 10).ToString();
        coins.text = "Coins: " + (theFallingController.coins * 100).ToString();
        theScore = (int)(Mathf.Round(theFallingController.highestPoint + 4) * 10) + theFallingController.coins * 100;
        score.text = "Score: " + (theScore).ToString();

        if(theScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
