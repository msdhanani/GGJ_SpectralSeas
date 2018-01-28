using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public Values

    public float MoveSpeed;

    //Private Values
    public GameObject Player;
    private bool PlayerAlive = true;
    private CharacterController PlayerControl;
    public Camera Player_cam;
    private Vector3 MoveDirection;
    private float Gravity = 9.8f;
    public bool Jumped = false;
    public float JumpLimit = 0.0f;
    public float JumpHeight = 10.0f;

    void Start()
    {
        PlayerControl = GetComponent<CharacterController>();
        MoveDirection = Vector3.zero;
       
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (PlayerAlive)
        {
            #region run stuff
            if (Input.GetKeyDown(KeyCode.LeftShift) && Player.GetComponent<cameraswitch>().is_player)
            {
                MoveSpeed = 10;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && Player.GetComponent<cameraswitch>().is_player)
            {
                MoveSpeed = 5;
            }
            #endregion
            #region Crouch stuff

            if (Input.GetKeyDown(KeyCode.LeftControl) && Player.GetComponent<cameraswitch>().is_player)
            {
                MoveSpeed = 2.5f;
             
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) && Player.GetComponent<cameraswitch>().is_player)
            {
                MoveSpeed = 5;
            }

            #endregion
            if (PlayerControl.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {

                    transform.position += Vector3.up  * JumpHeight * Time.deltaTime;

                }
            }
            float Horizon = Input.GetAxis("Horizontal");
            float Vert = Input.GetAxis("Vertical");

            Vector3 MoveSide = transform.right * Horizon * MoveSpeed;
            Vector3 MoveForward = transform.forward * Vert * MoveSpeed;
            PlayerControl.SimpleMove(MoveSide);
            PlayerControl.SimpleMove(MoveForward);


          


            if (MoveSpeed == 200)
            {
                PlayerAlive = false;
            }
        }
    }
}
