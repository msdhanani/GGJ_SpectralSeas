using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour {

    private bool IsIn = false;
    public AudioSource PipeSound;
    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject pipe3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsIn == true)
        {
            PipeSound.Stop();
            pipe1.SetActive(false);
            pipe2.SetActive(true);
            pipe3.SetActive(true);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsIn = true;
        }
    }

}
