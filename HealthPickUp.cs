using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public static HealthPickUp Instance {get; set;}

    private void Awake()
    {
        Instance = this; 
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Destroy Game Object;
            Destroy(gameObject);

            //Adding one more Count to the Armor PickUp
            //Currency System Script goes here;

            //Checking for the health Count if statement;

            //Settings actual armor potions available;

            //..Updating the Text Count for the Armor Pickup; 

        }
    }
}
