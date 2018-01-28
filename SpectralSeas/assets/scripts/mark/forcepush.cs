using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcepush : MonoBehaviour {

    public float ObMass = 300;
    public float PushAtMass = 100;
    public float PushingTime;
    public float ForceToPush;
    Rigidbody rb;
    public float vel;
    Vector3 dir;
    Vector3 lastPos;
    float _PushingTime = 0;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.mass = ObMass;

    }
    bool IsMoving()
    {
        if (rb.velocity.magnitude > 0.06f)
        {
            return true;
        }
        return false;

    }

    // Update is called once per frame
    void Update()
    {
        vel = rb.velocity.magnitude;
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("lift F!");
            rb.isKinematic = true;
        }

        if (rb.isKinematic == false)
        {
            Debug.Log("kinematic!");
            _PushingTime += Time.deltaTime;
            if (_PushingTime >= PushingTime)
            {
                _PushingTime = PushingTime;
            }

            rb.mass = Mathf.Lerp(ObMass, PushAtMass, _PushingTime / PushingTime);
            rb.AddForce(dir * ForceToPush, ForceMode.Force);
        }
        else
        {
            rb.mass = ObMass;
            _PushingTime = 0;

        }



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Ghost")
        {
            Debug.Log("PUSH!");

            if (Input.GetKey(KeyCode.F))
            {
                rb.isKinematic = false;

                dir = collision.contacts[0].point - transform.position;
                dir = -dir.normalized;

            }
        }

    }

}
