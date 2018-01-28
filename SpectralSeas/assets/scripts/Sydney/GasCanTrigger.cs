using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCanTrigger : MonoBehaviour {

    public bool nearby = false;
    public AudioSource GenSound;
    public bool triggered = false;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update () {
		if (nearby == true && triggered == false && inventory.Fuel > 0 && Input.GetButtonDown("Fire4"))
        {
            GenSound.Play();
            triggered = false;
            inventory.Fuel--;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.tag == "Player")
        {
            Debug.Log("HitIt");
            nearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearby = false;
        }
    }
}
