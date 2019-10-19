using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningPanel : MonoBehaviour
{
    public Text time;
    public Text score;
    public Text coins;
    public Text height;

    public int theScore;

    public Text onScreenScore;

    FallingController theFallingController;

    // Start is called before the first frame update
    void Start()
    {
        theFallingController = FindObjectOfType<FallingController>();
        time.text = "Time: " + Mathf.Round(1/Mathf.Round(theFallingController.endTime) * 150000).ToString();
        height.text = "Height: " + (Mathf.Round(theFallingController.highestPoint + 4) * 50).ToString();
        coins.text = "Coins: " + (theFallingController.coins * 100).ToString();

        theScore = (int)((Mathf.Round(theFallingController.highestPoint + 4) * 10) + theFallingController.coins * 100 + Mathf.Round(1 / Mathf.Round(theFallingController.endTime) * 150000));

        score.text = "Score: " + theScore.ToString();
        onScreenScore.text = "Score: \r\n" + theScore.ToString();

        if (theScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
