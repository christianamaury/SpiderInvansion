using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //What's the Camera needs to actually follow..
    public Transform lookAt;

    //Current Camera Position: Y: 15, Z: -37,
    //Previous Camera: 7.4, -29.79, Previous: 15f, -37f)
    //8.5f, -30.6
    private Vector3 offSet = new Vector3(0, 8.5f, -3.5f);

    //Transition speed variable; Previously 7.3f;
    private float speed = 7.5f;


    // Start is called before the first frame update
    void Start()
    {

        //..Looking for the actual Player;
        transform.position = lookAt.position + offSet;
        
    }

    //..Its executed after all the Update functions have been called;
    private void LateUpdate()
    {
        //Calling our Camera Movement Function;
        cameraMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void cameraMovement()
    {
        //Where the camera needs to be located;
        Vector3 desiredPosition = lookAt.position + offSet;


        //Lerping through the Vector positions;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
    }
}
