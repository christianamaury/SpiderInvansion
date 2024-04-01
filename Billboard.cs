using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //Camera Transform Reference;
    public Transform cam;

     void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
