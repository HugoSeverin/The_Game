using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float smoothSpeed;
    [SerializeField]
    private float minY, maxX, minX, maxY;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Use tag to find target
        target = PlayerController.instance.transform; // use singleton to find target 
    }

    private void LateUpdate()
    {
        //MARKER Method 1
        //transform.position = new Vector3(target.position.x, target.position.y, target.position.z);  //transform.position = camera.position

        //MARKER Method 2
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), smoothSpeed * Time.deltaTime);

        //MARKER Limit the range
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}

