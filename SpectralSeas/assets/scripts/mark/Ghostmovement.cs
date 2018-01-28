using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostmovement : MonoBehaviour {

    //Public Values

    public float MoveSpeed;
    //Private Values
    public GameObject Player;
    protected float verticalVelocity;
    protected float Gravity;
    protected float jumpForce;
    private CharacterController PlayerControl;

    void Start()
    {
        PlayerControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&& Player.GetComponent<cameraswitch>().is_ghost)
        {
            MoveSpeed =10;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && Player.GetComponent<cameraswitch>().is_ghost)
        {
            MoveSpeed = 5;
        }

   
            float Horizon = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        Vector3 MoveSide = transform.right * Horizon * MoveSpeed;
        Vector3 MoveForward = transform.forward * Vert * MoveSpeed;
        PlayerControl.SimpleMove(MoveSide);
        PlayerControl.SimpleMove(MoveForward);

       

   
    }
}
