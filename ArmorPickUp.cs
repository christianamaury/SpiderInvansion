using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickUp : MonoBehaviour
{
    public static ArmorPickUp Instance {get;set;}

    private void Awake()
    {
        Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Whenever the player touchs the Armor Potion;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Destroy Game Object..
            Destroy(gameObject);

            //Setting the Currency System Values;

            //Checking the potions amounts;

            //Updating the ArmorPickUps Text Counts; 
        }
    }
}
