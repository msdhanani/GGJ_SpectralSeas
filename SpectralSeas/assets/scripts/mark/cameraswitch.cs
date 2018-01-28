using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour {

    public Camera Player_cam;
    public Camera Ghost_cam;
    public GameObject Player_Ghost;
    public bool is_ghost;
    public bool is_player;
    public GameObject Player_human;
    public GameObject hand;
    public GameObject Light;
    // Use this for initialization
    void Start()
    {
        
        Playerview();
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCam();
 
    }


    public void ghostview()
    {
        Player_cam.enabled = false;
        Ghost_cam.enabled = true;
        //movement
        Player_Ghost.GetComponent<Ghostmovement>().MoveSpeed = 5;
        Player_human.GetComponent<movement_Updated>().MovementSpeed = 0;
        //look
        Player_human.GetComponent<movement_Updated>().MouseSensitivity = 0;
        Player_Ghost.GetComponent<PlayerLook>().LookSensitivity = 5;

        //jump stop
        Player_human.GetComponent<movement_Updated>().jumpStrenght = 0;
    }

    public void Playerview()
    {
        Player_cam.enabled = true;
        is_player = true;
        Ghost_cam.enabled = false;
        //movement
        Player_Ghost.GetComponent<Ghostmovement>().MoveSpeed = 0;
        Player_human.GetComponent<movement_Updated>().MovementSpeed = 5;
        //look
        Player_human.GetComponent<movement_Updated>().MouseSensitivity = 5;
        Player_Ghost.GetComponent<PlayerLook>().LookSensitivity = 0;
    }
    public void SwitchCam()
    {
        if (Input.GetKey("up")|| Input.GetButton("HumanMode"))
        {
            Debug.Log("player Mode");
            is_ghost = false;
            is_player = true;
            Player_Ghost.transform.position = Player_human.transform.position;
            Player_Ghost.GetComponent<MeshRenderer>().enabled = false;
            Player_Ghost.GetComponent<Collider>().enabled = false;
            Player_Ghost.GetComponent<CharacterController>().enabled = false;
            Player_human.GetComponent<movement_Updated>().jumpStrenght = 4;
            hand.GetComponent<MeshRenderer>().enabled = true;
            Light.GetComponent<Light>().enabled = true;
            Playerview();

        }
        if (Input.GetKey("down")|| Input.GetButton("GhostMode"))
        {
            Debug.Log("Ghost Mode");

            is_ghost = true;
            is_player = false;
            Player_Ghost.GetComponent<MeshRenderer>().enabled = true;
            Player_Ghost.GetComponent<Collider>().enabled = true;
            Player_Ghost.GetComponent<CharacterController>().enabled = true;
            Player_human.GetComponent<MeshRenderer>().enabled = false;
            Player_human.GetComponent<Collider>().enabled = false;
            hand.GetComponent<MeshRenderer>().enabled = false;
            Light.GetComponent<Light>().enabled = false;
            ghostview();
        }
    }

}
