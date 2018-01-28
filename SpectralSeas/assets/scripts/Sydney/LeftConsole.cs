using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftConsole : MonoBehaviour {

    private bool nearby = false;
    private bool triggered = false;
    public AudioSource GenSound;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nearby == true && Input.GetButtonDown("Fire4") && triggered == false)
        {
            GenSound.Play();
            triggered = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearby = false;
        }
    }
}
