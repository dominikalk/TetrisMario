using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFallingBlock : MonoBehaviour
{
    public System.Random rnd = new System.Random();

    public GameObject[] children;
    public PolygonCollider2D theColliders;
    public bool collided;
    int whatElementInArrayY = 0;
    int whatElementInArrayX;

    public bool changeColliderX = false;
    public bool changeColliderY = false;

    public bool rightStop;
    public bool leftStop;

    bool sent;

    StartScreen theFallingController;

    RoofSlow roofSlowPos;
    bool speedChanged;

    // Start is called before the first frame update
    void Start()
    {
        roofSlowPos = FindObjectOfType<RoofSlow>();
        theFallingController = FindObjectOfType<StartScreen>();
        whatElementInArrayX = rnd.Next(1, theFallingController.locationX.Length - 1);
        //gameObject.transform.position = new Vector3(theFallingController.locationX[whatElementInArrayX].transform.position.x, gameObject.transform.position.y, 0);
        InvokeRepeating("changeY", 0f, 0.05f);

        //transform.Rotate(0, 0, rnd.Next(0,4) * 90);
        //changeColliderX = true;
        //changeColliderY = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < roofSlowPos.GetComponent<Transform>().position.y && !collided && !speedChanged)
        {
            speedChanged = true;
            changeSpeed();
        }
    }

    void changeY()
    {
        if (!collided && whatElementInArrayY < 27)
        {
            whatElementInArrayY += 1;
            gameObject.transform.position = new Vector3(transform.position.x, theFallingController.locationY[whatElementInArrayY].transform.position.y);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(/*other.gameObject.transform.position.x < gameObject.transform.position.x */ other.transform.IsChildOf(gameObject.transform) != true)
    //  {
    //     collided = true;
    // }
    // }

    void changeSpeed()
    {
        CancelInvoke("changeY");
        InvokeRepeating("changeY", 0f, 0.3f);
    }
}
