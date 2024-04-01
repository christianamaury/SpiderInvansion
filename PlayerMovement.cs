using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance {get; set;}

    public float speed = 6.2f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigibody;
    int floorMask;
    float camRayLenght = 100f;

     void Awake()
    {
        //Setting references;
        floorMask = LayerMask.GetMask("Floor");

        //Animator Component from the Player;
        anim = GetComponent<Animator>();

        //Rigidbody Component from the Player; 
        playerRigibody = GetComponent<Rigidbody>();
    }

    //Calls method that runs physics; 
    void FixedUpdate()
    {
        //Movement Settings for the player;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        turningAround();
        Animating(h, v); 
    }

    //Move function for our Character;
    private void Move(float h, float v)
    {
        //X & Z are basically set on the floor;
        //movement is a Vector3 Variable
        movement.Set(h, 0f, v);

        //Making sure that the direction size of the movement is always 1: Diagonal
        //Time.deltaTime = The time between each update call. 
        movement = movement.normalized * speed * Time.deltaTime;

        //MovePosition method moves a rigidbody;
        //Current Transform Position of the player + The movement
        playerRigibody.MovePosition(transform.position + movement);
    }

    private void turningAround() {

        //Ray coming out from the Camera;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            //..If we hit something;
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Way of storing a Rotation; In order to forward the Vector of the Player; 
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigibody.MoveRotation(newRotation);

        }

    }

    private void Animating(float h, float v)
    {
        //Returning whether true or false if its 0
        bool isRunning = h != 0f || v != 0f;

        //Setting the animation for the Animator Component;
        anim.SetBool("IsRunning", isRunning);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
