using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class PlayerWorldInteraction : MonoBehaviour {
    public GameObject Textbox;
    public AudioSource Closed_door;
    public AudioSource Demon_squeal;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "KeyCard")
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("keypickup");
                inventory.Keys++;
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Door" && inventory.Keys >= 1)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("keypickup");
                inventory.Keys--;
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        else if (other.gameObject.tag == "Fuel"&& Input.GetKey(KeyCode.F))
        {
            inventory.Fuel++;
            Debug.Log("fuel_can");
            Debug.Log(inventory.Fuel);
            Destroy(other.gameObject);
        }
        if (Input.GetKey(KeyCode.F) && other.gameObject.tag == "Flashlight")
        {
            inventory.Flashlight = true;
        }



        if (other.gameObject.tag == "SoundBall")
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("rawr");
                other.gameObject.GetComponent<AudioSource>().Play();
             //   Demon_squeal.Play();
            }
        }

        if (other.gameObject.tag == "portal")
        {
           

            Cursor.visible = true ;
  
            SceneManager.LoadScene("Floor_1");
        }


        if (other.gameObject.tag == "Portal1")
        {


            Cursor.visible = true;

            SceneManager.LoadScene("Credits");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            GetComponent<movement_Updated>().is_alive = false;
        }

      


    }
}
