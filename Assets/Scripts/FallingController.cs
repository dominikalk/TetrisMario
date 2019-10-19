using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FallingController : MonoBehaviour
{

    public System.Random rnd = new System.Random();

    public Transform[] locationX;
    public Transform[] locationY;
    public Sprite[] blockColours;
    public GameObject[] blockShapes;

    public float fallingSpeed = 0.5f;
    public bool blockFalling;

    PlayerController thePlayer;
    public GameObject wallRight2;
    public Transform heightToReach;

    public float highestPoint;
    public int coins;

    public bool gameOver;
    public GameObject gameOverPanel;

    public bool winning;
    public GameObject winningPanel;

    float startTime;
    public float endTime;

    public Text scoreText;
    public bool changeScore;
    public Text highScore;

    public Animator fadeOutPanel;

    public bool spinnable;

    public AudioSource gemSound;
    public AudioSource blockSound;
    public AudioSource jumpSound;
    public AudioSource mainMusic;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("HighScore", 0);
        thePlayer = FindObjectOfType<PlayerController>();
        highestPoint = -5;
        Time.timeScale = 1f;
        startTime = Time.time;
        highScore.text = "HighScore: \r\n" + PlayerPrefs.GetInt("HighScore");
        //InvokeRepeating("spawnBlock", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !gameOver && !winning)
        {
            gameOver = true;
        }
        else if (Input.GetKeyDown(KeyCode.R) && (gameOver || winning))
        {
            Time.timeScale = 1f;
            StartCoroutine(FadeOut("StartScene"));
        }

        if (changeScore)
        {
            scoreText.text = "Score: \r\n" + ((Mathf.Round(highestPoint + 4) * 10) + coins * 100).ToString();
            changeScore = false;
        }

        if(thePlayer.transform.position.y > highestPoint)
        {
            highestPoint = thePlayer.transform.position.y;
            changeScore = true;
        }

        if (gameOver)
        {
            thePlayer.myRigidbody.gravityScale = 0;
            gameOverPanel.SetActive(true);
            //Time.timeScale = 0;
        }

        if (winning)
        {
            endTime = Time.time - startTime;
            winningPanel.SetActive(true);
            //Time.timeScale = 0;
        }

        if (thePlayer.transform.position.y > heightToReach.position.y)
        {
            wallRight2.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (!blockFalling)
        {
            spawnBlock();
            blockFalling = true;
        }
    }

    void spawnBlock()
    {
        Sprite theSprite = blockColours[rnd.Next(0, blockColours.Length)];

        int temp = rnd.Next(0, 5);
        if(temp == 4)
        {
            spinnable = false;
        }
        else
        {
            spinnable = true;
        }

        GameObject theShape = blockShapes[temp];

        BlockShapeChildren theShapeScript = theShape.GetComponent <BlockShapeChildren>();
        for(int i = 0; i < theShapeScript.children.Length; i++)
        {
            theShapeScript.children[i].GetComponent<SpriteRenderer>().sprite = theSprite;
        }

        Instantiate(theShape, new Vector3(locationX[rnd.Next(2,locationX.Length-2)].transform.position.x, locationY[0].transform.position.y, 0), Quaternion.Euler(0,0,0));
    }

    public IEnumerator FadeOut(string scene)
    {
        mainMusic.GetComponent<Animator>().SetTrigger("EndScene");
        fadeOutPanel.SetTrigger("EndScene");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }
}
