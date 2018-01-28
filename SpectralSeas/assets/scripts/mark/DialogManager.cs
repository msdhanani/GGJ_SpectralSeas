using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public Text NPC;
    public Text Chat;
    public CharacterController PlayerController;
  //  public Animator animator;
    public GameObject Diagbox;
    public bool IsChatting;
    public int current;
    public int Interaction_1 = 6;
    public int Interaction_2;
    public int Interaction_3;
    public int Interaction_4;
    public int Interaction_5;
    public int Interaction_6;
    public int Interaction_7;
    public int Interaction_8;
    public int Interaction_9;
    public bool Interaction_1_bool = false;
    public bool Interaction_2_bool=false;
    public bool Interaction_3_bool=false;
    public bool Interaction_4_bool=false;
    public bool Interaction_5_bool=false;
    public bool Interaction_6_bool=false;
    public bool Interaction_7_bool=false;
    public bool Interaction_8_bool=false;
    public bool Interaction_9_bool=false;
  //  private Queue<string> Chatbox;
    public string[] Dlines;
	// Use this for initialization
	void Start ()
    {
     //   Chatbox = new Queue<string>();
        Diagbox.SetActive(false);

    }
    void Update()
    {
        if (IsChatting && Input.GetKeyDown(KeyCode.Return))
        {
            PlayerController.enabled = true;
            current+=1;
            Debug.Log(current);


            if (current >= 6 && Interaction_1_bool==true)
            {
               
                IsChatting = false;
                Diagbox.SetActive(false);
                Diagbox.SetActive(false);
            }
        }
        if (current >= Dlines.Length)
        {
            Diagbox.SetActive(false);
            Diagbox.SetActive(false);
            Debug.Log("this");
            current = 0;
        }

        Chat.text = Dlines[current];
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Dialogue1")
        {
            Debug.Log("d1");
            current = 0;
            IsChatting = true;
            Interaction_1_bool = true;
            Diagbox.SetActive(true);

            PlayerController.enabled=false;
            Destroy(other.gameObject);
          
        }
    }
     void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
    Interaction_1_bool = false;
    Interaction_2_bool = false;
    Interaction_3_bool = false;
    Interaction_4_bool = false;
    Interaction_5_bool = false;
    Interaction_6_bool = false;
    Interaction_7_bool = false;
    Interaction_8_bool = false;
    Interaction_9_bool = false;
    }

 
}
