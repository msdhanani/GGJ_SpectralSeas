using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRoam : MonoBehaviour {
    public GameObject Target;
    public float movespeed;
    bool facingRight = true;
    protected float distance_View;
   public  bool gameover;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {

        distance_View = Vector3.Distance(Target.transform.position, transform.position);


        Chase_Player();

    }


    void Chase_Player()//Me And My Friends
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.transform.position.x, Target.transform.position.y - 0.5f, Target.transform.position.z), movespeed * Time.deltaTime);
        if (transform.position.y < 2.5)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        }

        if (Target.transform.position.x > transform.position.x)
        {
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = !facingRight;
            }
        }
        if (Target.transform.position.x < transform.position.x)
        {
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = !facingRight;
            }
        }

        if (Target.transform.position == transform.position)
        {
            gameover = true;
        }
    }
}
