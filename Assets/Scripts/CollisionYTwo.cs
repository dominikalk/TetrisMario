using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionYTwo : MonoBehaviour
{

    public BlockShapeChildren theBlockShapeTwo;

    public bool walling = true;

    // Start is called before the first frame update
    void Start()
    {
        //if(GetComponentInParent<Transform>().transform.rotation.z > -1 && GetComponentInParent<Transform>().transform.rotation.z < 1 || GetComponentInParent<Transform>().transform.rotation.z == 180 || GetComponentInParent<Transform>().transform.rotation.z == -180)
        //{
        //gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        //   walling = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (theBlockShapeTwo.changeColliderY == true)
        {
            //gameObject.GetComponent<PolygonCollider2D>().enabled = !gameObject.GetComponent<PolygonCollider2D>().enabled;
            walling = !walling;
            theBlockShapeTwo.changeColliderY = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Gem" && other.tag != "Player")
        {
            if (walling)
            {
                if (other.tag == "WallLeft")
                {
                    theBlockShapeTwo.leftStop = true;
                }
                else if (other.tag == "WallRight")
                {
                    theBlockShapeTwo.rightStop = true;
                }
                else if (other.transform.position.x > gameObject.transform.position.x)
                {
                    theBlockShapeTwo.rightStop = true;
                }
                else if (other.transform.position.x < gameObject.transform.position.x)
                {
                    theBlockShapeTwo.leftStop = true;
                }
            }
            if (!walling)
            {
                theBlockShapeTwo.collided = true;
                theBlockShapeTwo.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
