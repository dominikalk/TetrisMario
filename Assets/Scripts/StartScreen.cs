using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{

    public System.Random rnd = new System.Random();

    public Transform[] locationX;
    public Transform[] locationY;
    public Sprite[] blockColours;
    public GameObject[] blockShapes;

    public float fallingSpeed = 0.3f;

    public Text highScore;

    public Animator fadeOutPanel;

    public AudioSource mainMusic;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        Time.timeScale = 1f;
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
        InvokeRepeating("spawnBlock", 0f, 2.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine("FadeOut");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    void spawnBlock()
    {
        Sprite theSprite = blockColours[rnd.Next(0, blockColours.Length)];
        GameObject theShape = blockShapes[rnd.Next(0, blockShapes.Length)];

        StartFallingBlock theShapeScript = theShape.GetComponent<StartFallingBlock>();
        for (int i = 0; i < theShapeScript.children.Length; i++)
        {
            theShapeScript.children[i].GetComponent<SpriteRenderer>().sprite = theSprite;
        }

        int shapeRotation = rnd.Next(0, 4) * 90;

        Instantiate(theShape, new Vector3(locationX[rnd.Next(1, 19)].transform.position.x, locationY[0].transform.position.y, 0), Quaternion.Euler(0, 0, 0));
    }

    public IEnumerator FadeOut()
    {
        mainMusic.GetComponent<Animator>().SetTrigger("EndScene");
        fadeOutPanel.SetTrigger("EndScene");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainScene");
    }
}
