using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    FallingController theFallingController;

    // Start is called before the first frame update
    void Start()
    {
        theFallingController = FindObjectOfType<FallingController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            theFallingController.gemSound.Play();
            theFallingController.coins += 1;
            theFallingController.changeScore = true;
            gameObject.SetActive(false);
        }
    }
}
