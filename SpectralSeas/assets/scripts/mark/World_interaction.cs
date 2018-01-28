using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_interaction : MonoBehaviour
{
    public bool keypress;
    public GameObject Player_Ghost;
    public GameObject Human_player;
    void OnTriggerStay(Collider target)
    {
        // Use this for initialization
        if (target.gameObject.tag.Equals("Box") == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButton("ObjectGrab"))
            {
                target.transform.parent = transform;
                keypress = true;
                Player_Ghost.GetComponent<Ghostmovement>().MoveSpeed = (Player_Ghost.GetComponent<Ghostmovement>().MoveSpeed/2);
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                target.transform.parent = null;
                keypress = false;
                Player_Ghost.GetComponent<Ghostmovement>().MoveSpeed = 5;

            }
        }

        if (Player_Ghost.GetComponent<MeshRenderer>().enabled == true && target.tag.Equals("ghostDoor"))
        {
            target.GetComponent<MeshCollider>().enabled = false;

        }
        else if (Player_Ghost.GetComponent<MeshRenderer>().enabled == true && target.tag.Equals("ghostDoor"))
        {
            target.GetComponent<MeshCollider>().enabled = true;
        }



    }
    private void OnTriggerExit(Collider other)
    {

        if ( Human_player.GetComponent<cameraswitch>().is_ghost)
        {
            other.GetComponent<MeshCollider>().enabled = true;

        }
    }
}
