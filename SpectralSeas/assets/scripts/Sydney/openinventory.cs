using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class openinventory : MonoBehaviour
{
    private bool isFuel = false;
    private bool isFlashlight = false;
    private bool isKeyCard = false;
    private bool isKey = false;
    private bool isBatteries = false;
    private bool isWrench = false;
    private bool isBallRed3 = false;
    private bool isBallBlack5 = false;
    private bool isBallGreen5 = false;
    private bool isBallYellow6 = false;
    private bool isBallPurple6 = false;
    private bool isBallOrange6 = false;
    private bool isBallBlue4 = false;

    private void Update()
    {
        if (isFuel == true)
        {
            inventory.Fuel +=3;
        }
        else if (isFlashlight == true)
        {
            inventory.Flashlight = true;
        }
        else if (isKeyCard == true)
        {
            inventory.Keycard++;
        }
        else if (isKey == true)
        {
            inventory.Keys++;
        }
        else if (isBatteries == true)
        {
            inventory.Batteries++;
        }
        else if (isWrench == true)
        {
            inventory.Wrench = true;
        }
        else if (isBallRed3 == true)
        {
            inventory.BallRed3 = true;
        }
        else if (isBallBlack5 == true)
        {
            inventory.BallBlack5 = true;
        }
        else if (isBallGreen5 == true)
        {
            inventory.BallGreen5 = true;
        }
        else if (isBallYellow6 == true)
        {
            inventory.BallYellow6 = true;
        }
        else if (isBallPurple6 == true)
        {
            inventory.BallPurple6 = true;
        }
        else if (isBallOrange6 == true)
        {
            inventory.BallOrange6 = true;
        }
        else if (isBallBlue4 == true)
        {
            inventory.BallBlue4 = true;
        }
    }
    void OnTriggerEnter(Collider collide)
    {
        if (Input.GetButtonDown("Fire4") && collide.tag == "Flashlight")
        {
            isFlashlight = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "KeyCard")
        {
            isKeyCard = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "Key")
        {
            isKey = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "Batteries")
        {
            isBatteries = true;
        }
        else if (collide.tag == "Fuel" && Input.GetButtonDown("Fire4"))
        {
            isFuel = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "Wrench")
        {
            isWrench = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "BallRed3")
        {
            isBallRed3 = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "BallBlack5")
        {
            isBallBlack5 = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "BallGreen5")
        {
            isBallGreen5 = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "BallYellow6")
        {
            isBallYellow6 = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "BallPurple6")
        {
            isBallPurple6 = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "BallOrange6")
        {
            isBallOrange6 = true;
        }
        else if (Input.GetButtonDown("Fire4") && collide.tag == "BallBlue4")
        {
            isBallBlue4 = true;
        }
    }
}
