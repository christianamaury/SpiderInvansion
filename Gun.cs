using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public static Gun Instance {get; set;}
  
    //Weapong Damage; 
    public float gunDamage = 10f;

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
    public void Shoot()
    {
        RaycastHit hit;
        //Shoot from the angle that we're facing..
        //Returns true if we actuall hit something; //Check if we hit something..
        if (Physics.Raycast(gunEndBarrel.transform.position, gunEndBarrel.transform.forward, out hit, range))
        {
            //Name of the object that we did hit
            Debug.Log(hit.transform.name);

            //Looking for the target with the EnemyC Component class on them.
            EnemyC target = hit.transform.GetComponent<EnemyC>();

            if (target != null)
            {
                //Passing our Damage Variable;
                EnemyC.Instance.EnemyTakeDamage(gunDamage);
            }
        }

    }
}
