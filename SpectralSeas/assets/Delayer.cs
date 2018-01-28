using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Delayer : MonoBehaviour {
    public float timer =15;
	// Use this for initialization
	void Start () {
        timer = 15;
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer<1)
        {

            SceneManager.LoadScene(2);
        }
	}
}
