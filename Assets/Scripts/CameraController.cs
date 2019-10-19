using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float followAhead;
    private Vector3 targetPos;
    public float smoothing;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    bool passedPos1;
    bool passedPos2;
    bool passedPos3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, pos3.position.y + followAhead, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(target.transform.position.y > pos2.position.y)
        {
            passedPos2 = true;
            targetPos = new Vector3(transform.position.x, pos2.position.y + followAhead - 2, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
        }
        else if (target.transform.position.y > pos1.position.y)
        {
            passedPos1 = true;
            targetPos = new Vector3(transform.position.x, pos1.position.y + followAhead - 2, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
        }
        else if (target.transform.position.y > pos3.position.y)
        {
            passedPos1 = true;
            targetPos = new Vector3(transform.position.x, pos3.position.y + followAhead, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
        }
    }
}
