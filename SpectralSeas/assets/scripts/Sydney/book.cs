using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    public static int Code;

	// Use this for initialization
	void Start () {
        Code = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetCode();
    }

    int GetCode()
    {
        if (Input.GetKey(KeyCode.B))
        {
            Code = Random.Range(1000, 9999);
        }
        return Code;
    }
}
