using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public static Gun Instance {get; set;}
  
    //Weapong Damage; 
    public float damage = 10f;

    //Range in order to be able to shoot;
    public float range = 100f;

    //Shoot from this Transform Game Object;
    public Transform gunEndBarrel; 

    // Start is called before the first frame update;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if the user is pressing the mouse to shoot, Left Mouse Click;
        //For the Mobile Environment needs to add when a button is click
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //Raycasting to shoot from our camera to the impact point;
    public void Shoot(){

    }
}
