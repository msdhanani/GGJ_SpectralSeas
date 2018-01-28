using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEnter : MonoBehaviour {

    private bool IsIn = false;
    public AudioSource PipeSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (IsIn == true)
        {
            PipeSound.Play();
        }
	}

    void OnTriggerstay(Collider other)
    {
        if (other.tag == "Player")
        {
            IsIn = true;
        }
    }
}
