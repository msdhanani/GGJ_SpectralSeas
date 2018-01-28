using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_Updated : MonoBehaviour {
    public Transform playercam, character, centerpoint;
    private CharacterController controller;
    public GameObject Player;
    private float mouseX, mouseY;
    public float MouseSensitivity =10.0f;
    private float MoveFrontBack, MoveLeftRigth;
    public float MovementSpeed = 2.0f;
    public float CameraZoom = -2.5f;
    public float rotationspeed=25;
    public float gravity = 9.8f;
    public float jumpStrenght =4;
    public float Vertical_velocity;
    public bool is_alive = true;
    public GameObject SB;
    public GameObject PS;
    // Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        SB =  GameObject.FindGameObjectWithTag("Sound_Ball");
        PS = GameObject.FindGameObjectWithTag("Particles");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (is_alive)
        {
        cameramovement();
        }
        if (!is_alive)
        {
            transform.position = new Vector3 (0, 0, 0);
            is_alive = true;
        }
        Soundball();
	}


    void cameramovement()
    {
        //playercam.transform.localPosition = new Vector3(0, 0, CameraZoom);
        mouseX += Input.GetAxis("Mouse X")*MouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y")*MouseSensitivity;
        #region JUmp
        if ((Input.GetButtonDown("Fire3") && Player.GetComponent<cameraswitch>().is_player))
        {
            Debug.Log("sprint");
            MovementSpeed = 10;
        }
        else if (Input.GetButtonUp("Fire3") && Player.GetComponent<cameraswitch>().is_player )
        {
            Debug.Log("sprint");
            MovementSpeed = 5;
        }
        #endregion
        #region Crouch stuff
        if (Input.GetKeyDown(KeyCode.LeftControl) && Player.GetComponent<cameraswitch>().is_player)
        {
            MovementSpeed = 2.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && Player.GetComponent<cameraswitch>().is_player)
        {
            MovementSpeed = 5;
        }
        #endregion
        mouseY = Mathf.Clamp(mouseY ,-60f, 60f);
        //playercam.LookAt(centerpoint);
        centerpoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

        if (controller.isGrounded)
        {
            Vertical_velocity = -gravity * Time.deltaTime;
            if (Input.GetButton("Jump"))
            {
                Vertical_velocity = jumpStrenght;
            }
        }
        else if (!controller.isGrounded)
        {
            Vertical_velocity -= gravity * Time.deltaTime;
        }

        MoveLeftRigth = Input.GetAxis("Horizontal")*MovementSpeed;
        
        MoveFrontBack = Input.GetAxis("Vertical")*MovementSpeed;

        Vector3 movement = new Vector3 (MoveLeftRigth,Vertical_velocity,MoveFrontBack);
        movement = character.rotation * movement;
        character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        centerpoint.position = new Vector3(character.position.x, character.position.y+1, character.position.z);

        if (Input.GetAxis("Vertical")!=0)
        {
            Quaternion turnangle = Quaternion.Euler(0,centerpoint.eulerAngles.y ,0);
            character.rotation = Quaternion.Slerp(character.rotation,turnangle,Time.deltaTime*rotationspeed);
        }
      
    }



    void Soundball()
    {

        if (Vector3.Distance(SB.transform.position,transform.position)<2)
        {
            if (!SB.transform.GetComponent<AudioSource>().isPlaying)
            {
            SB.transform.GetComponent<AudioSource>().Play();

            }
        }

    }
    void PsActivate()
    {

        if (Vector3.Distance(SB.transform.position, transform.position) < 2)
        {

            PS.transform.GetComponent<ParticleSystem>().Play();
        
        }

    }
}
