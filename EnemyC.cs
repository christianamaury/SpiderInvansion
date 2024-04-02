using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For the Navs Mesh Library; 
using UnityEngine.AI; 

public class EnemyC : MonoBehaviour
{
    public static EnemyC Instance {get; set;}

    //Enemy health;
    public float startingEnemyHealth = 100f;
    public float currentEnemyHealth; 

    //Enemy sinking effect when they died;
    public float sinkSpeedEffect = 2.5f;

    //Points when an enemy gets killed;
    public int scoreValue = 1;

    //Its enemy sinking on the map;
    //public bool isSinking;

    //Its enemy Dead;
    public bool isEnemyDead = false;

    //Reference of the Capsule Collider Component;
    CapsuleCollider capsuleCollider; 


    NavMeshAgent enemy;
    private Transform playerTransform;

    //Enemy Anim Controller Parameters: isPlayerDead, isEnemyDead,isRunning,  attackPlayer: All Boolean Variables;
    private Animator enemyAnim;

    public bool isDamaging = false;

    private void Awake()
    {
        Instance = this;
        //Looking for the Player Transform Component; 
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //..Enemy Audio Source Component for the enemyAudio;

        //Getting Capsule Collider Component;
        capsuleCollider = GetComponent<CapsuleCollider>();

        //Equal to our current Value; 
        currentEnemyHealth = startingEnemyHealth;


    }

    // Start is called before the first frame update
    void Start()
    {
        //Getting Animator & NavMesh Agent Component;
        enemyAnim = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //..Calling enemyMovement function;
        enemyMovement();

       
    }

    //Removed from the parameters the Vector3 hitpoint
    public void EnemyTakeDamage(int amount)
    {
        //If Enemy is not Dead yet..
        if(isEnemyDead)
        {
            return; 
        }

        //Play enemy Audio here;


        //Health Damage;
        currentEnemyHealth = currentEnemyHealth - amount;

        //Particles Hitpoint here;
        //hitParticles.transform.position = hitPoint
        //hitParticles.Play();


        //Enemy Health
        if(currentEnemyHealth <= 0)
        {
           //Enemy Death Class Here;

        }
    }

    public void EnemyDeath()
    {
        isEnemyDead = true;
        //Needs to be tested it.. 
        capsuleCollider.isTrigger = true;
        //Playing Death Animation for the Enemy; 
        enemyAnim.SetBool("isEnemyDead", true);
        //anim.Dead animation..
        //play death audio();
        
        //Destroying EnemyObject; 
        Destroy(gameObject, 2f);

    }

    public void enemyMovement()
    {
        //Play Enemy Animation;
        enemyAnim.SetBool("isRunning", true);

        //Enemy following player;
        enemy.SetDestination(playerTransform.position);

    }

    public void attackAnimation()
    {
        //Attack Player Animation;
        enemyAnim.SetBool("attackPlayer", true);

    }

    public void stoppingAttackAnimation()
    {
        //Stop Attack Player Animation;
        enemyAnim.SetBool("attackPlayer", false);
    }

    //When Colliders enters.. Attack Player
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isDamaging = true;
            if (isDamaging == true)
            {
                //Attack Animation;
                attackAnimation();

                //Damage on the Player: Stamina Bar Call Below;


                //Setting variable to false again; Needs to be tested it below;
                //isDamaging = false; 
            }

        }
    }

    //Stop attacking player;
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isDamaging = false;

            //Stop Attack Animation; 
            stoppingAttackAnimation();
        }
    }
}
