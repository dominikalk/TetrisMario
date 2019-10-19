using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theFallingController.winning = true;
        }   
    }
}
