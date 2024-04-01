using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{

    public static HealthBar Instance {get; set;}

    public Slider healthBar;
    public Slider armorBar;

    //Reference of the Armor Health Points;
    public float armorHealthPoints = 15.5f;
    public float maxArmorHealth = 50f;

    //Max Health Value for the Player; 
    public float maxHealth = 100f;
    public float healthPoints = 15.5f;

    //Damage to the Player; Previously 0.01f
    public float enemyDamage = 2.3f; 

    private void Awake()
    {
        Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        armorBar.maxValue = maxArmorHealth;

        //Currency System Class Below Here...

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrantArmorHealth()
    {
        //..If Curreny System Statement
    }

    public void GrantHealth()
    {
        //..If Curreny System Statement
    }

    //Attack Player
    public void AttackPlayer()
    {
        //Updating Armor Bar Value;
        if (maxArmorHealth > 0)
        {
            maxArmorHealth = maxArmorHealth - enemyDamage;

            //Update Armor Bar;
            armorBar.value = maxArmorHealth;
        }

        if (maxArmorHealth <=0)
        {
            maxHealth = maxHealth - enemyDamage;

            //Updating Health Bar;
            healthBar.value = maxHealth;

            //If it's less than 0, start level again..
            if (maxHealth <= 0)
            {
                //Restart Level Class Here;

            }

        }
    }
}
