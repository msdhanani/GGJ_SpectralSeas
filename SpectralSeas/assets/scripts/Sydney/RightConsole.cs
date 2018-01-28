using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightConsole : MonoBehaviour {

    private bool nearby = false;
    public AudioSource TowerSound;
    public Light AreaLight;
    private bool isLightOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire4") && nearby == true && isLightOn == false)
        {
            TowerSound.Play();
            AreaLight.enabled = true;
            isLightOn = true;
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Ghost")
        {
            nearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Ghost")
        {
            nearby = false;
        }
    }
}
