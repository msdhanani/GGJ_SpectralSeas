using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAtrigger : MonoBehaviour {


    private bool IsIn;
    public AudioSource PA;
    private bool Triggered = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsIn == true && Triggered == false)
        {
            PA.Play();
            Triggered = true;
        }
        else if (IsIn == false)
        {
            PA.Stop();
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Ghost")
        {
            IsIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Ghost")
        {
            IsIn = false;
        }
    }
}
