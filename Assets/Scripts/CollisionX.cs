using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionX : MonoBehaviour
{

    public BlockShapeChildren theBlockShape;

    public bool walling = true;

    // Start is called before the first frame update
    void Start()
    {
        //if (GetComponentInParent<Transform>().transform.rotation.z > 89 && GetComponentInParent<Transform>().transform.rotation.z < 90 || GetComponentInParent<Transform>().transform.rotation.z < -89 && GetComponentInParent<Transform>().transform.rotation.z > -90)
        //{
            //gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        //    walling = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (theBlockShape.changeColliderX == true)
        {
            //gameObject.GetComponent<PolygonCollider2D>().enabled = !gameObject.GetComponent<PolygonCollider2D>().enabled;
            walling = !walling;
            theBlockShape.changeColliderX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag != "Gem" && other.tag != "Player")
        {
            if (walling)
            {
                if (other.tag == "WallLeft")
                {
                    theBlockShape.leftStop = true;
                }
                else if (other.tag == "WallRight")
                {
                    theBlockShape.rightStop = true;
                }
                else if (other.transform.position.x > gameObject.transform.position.x)
                {
                    theBlockShape.rightStop = true;
                }
                else if (other.transform.position.x < gameObject.transform.position.x)
                {
                    theBlockShape.leftStop = true;
                }
            }
            if (!walling)
            {
                theBlockShape.collided = true;
                theBlockShape.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
