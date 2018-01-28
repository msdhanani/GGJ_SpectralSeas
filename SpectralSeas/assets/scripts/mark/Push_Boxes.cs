using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Boxes : MonoBehaviour {
    public Camera Ghost_camera;
    public GameObject Box;
    float Boxzise;
    float DropReach = 1;
    float Reach = 5;
   public float displacement;
    Vector3 PrevPos;
    GameObject GrabBox(float Pushrange)
    {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycast;
        Vector3 target = position + Ghost_camera.transform.forward * Pushrange;
        if (Physics.Linecast(position, target, out raycast))
        {
            return raycast.collider.gameObject;
        }
        return null;
    }
    // Update is called once per frame
    void grabBox(GameObject Box)
    {
        if (Box == null || !is_box(Box))
        {
            return;
        }
            this.Box = Box;
            Boxzise = this.Box.GetComponent<MeshRenderer>().bounds.size.magnitude;
          

    }

    void dropBox(float PushForce)
    {
        if (Box == null)
        {
            return;
        }
            if (Box.GetComponent<Rigidbody>()!= null)
            {
                Vector3 PushVector = Box.transform.position - PrevPos;
                float speed = PushVector.magnitude / Time.deltaTime;
                Vector3 pushVelocity = speed * PushVector.normalized;

                pushVelocity += Ghost_camera.transform.forward * PushForce;
                Box.GetComponent<Rigidbody>().velocity = pushVelocity;
                Box.GetComponent<Rigidbody>().useGravity = true;
            }
            Box = null;

    }        
    bool is_box(GameObject PickUp_obj)
    {

        return  PickUp_obj.GetComponent<Rigidbody>() != null;
    }
    bool sumama = true;
    void Update ()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("PrimaryAttack") != 0)
        {
            Debug.Log("fire");
            if (Box == null)
            {
              grabBox(GrabBox(5));
            }
            else
                dropBox(displacement);
        }
        
        if (Input.GetKeyUp(KeyCode.Space) || (Input.GetAxis("PrimaryAttack") == 0 && sumama))
        {
            dropBox(displacement);
            sumama = false;
        }
        if (Box!= null)
        {
            PrevPos = Box.transform.position;
            Vector3 DropPosition = gameObject.transform.position + Ghost_camera.transform.forward * Boxzise;
            Box.transform.position = DropPosition;
        }		
	}
}
