using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_ShowSwords : MonoBehaviour
{

    public GameObject sword1;
    public GameObject sword2;
    public GameObject Spider;
    public GameObject dialogueGUI;
    public GameObject dialogueGUI_uitleg;
    public GameObject dialogueGUI_volgende;
    public KeyCode DialogueInput = KeyCode.E;
    public GameObject Player;
    WaitForSeconds delay = new WaitForSeconds(5f);

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("werkt");
        if (other.gameObject.tag == "Player" && gameObject.tag == "Sword1")
        {
            Debug.Log("werkt 2");
            dialogueGUI.SetActive(true);
            DoSomething_Sword1();
        }
        else if(other.gameObject.tag == "Player" && gameObject.tag == "Sword2")
        {
            Debug.Log("werkt 3");
            dialogueGUI.SetActive(true);
            DoSomething_Sword2();
        }
    }

    private void DoSomething_Sword1()
    {
        GameObject Player = GameObject.Find("Player");
        ShowWeapon playerScript = Player.GetComponent<ShowWeapon>();
        SimpleCharacterControl playerScript1 = Player.GetComponent<SimpleCharacterControl>();
        playerScript1.m_jumpForce = 0f;
        playerScript1.m_moveSpeed = 0f;
        playerScript1.m_turnSpeed = 0f;
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueGUI.SetActive(false);
            playerScript.showItem1 = true;
            transform.gameObject.tag = "Untagged";
            if (playerScript.showItem2 == true)
            {
                playerScript.showItem1 = false;
                playerScript.showItem2 = false;
                dialogueGUI_uitleg.SetActive(true);
                Spider.SetActive(true);
                Invoke("Wait_Sword1", 5.0f);
            }
            else
            {
                playerScript.showItem1 = false;
                dialogueGUI_volgende.SetActive(true);
                Invoke("Wait_Sword1", 5.0f);
            }
        }
    }

    private void DoSomething_Sword2()
    {

        GameObject Player = GameObject.Find("Player");
        ShowWeapon playerScript = Player.GetComponent<ShowWeapon>();
        SimpleCharacterControl playerScript1 = Player.GetComponent<SimpleCharacterControl>();
        playerScript1.m_jumpForce = 0f;
        playerScript1.m_moveSpeed = 0f;
        playerScript1.m_turnSpeed = 0f;
        Debug.Log("werkt");
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueGUI.SetActive(false);
            playerScript.showItem2 = true;
            transform.gameObject.tag = "Untagged";
            if (playerScript.showItem1 == true)
            {
                playerScript.showItem2 = false;
                playerScript.showItem1 = false;
                dialogueGUI_uitleg.SetActive(true);
                Spider.SetActive(true);
                Invoke("Wait_Sword2", 5.0f);
            }
            else
            {
                playerScript.showItem2 = false;
                dialogueGUI_volgende.SetActive(true);
                Invoke("Wait_Sword2", 5.0f);
            }
        }
    }


    void Wait_Sword1()
    {
        ShowWeapon playerScript = Player.GetComponent<ShowWeapon>();
        SimpleCharacterControl playerScript1 = Player.GetComponent<SimpleCharacterControl>();
        dialogueGUI_volgende.SetActive(false);
        dialogueGUI_uitleg.SetActive(false);
        Destroy(sword1);
        playerScript.showItem1 = true;
        playerScript1.m_jumpForce = 5.5f;
        playerScript1.m_moveSpeed = 4f;
        playerScript1.m_turnSpeed = 300f;
        Debug.Log("doet het");
    }

    void Wait_Sword2()
    {
        ShowWeapon playerScript = Player.GetComponent<ShowWeapon>();
        SimpleCharacterControl playerScript1 = Player.GetComponent<SimpleCharacterControl>();
        dialogueGUI_volgende.SetActive(false);
        dialogueGUI_uitleg.SetActive(false);
        Destroy(sword2);
        playerScript.showItem2 = true;
        playerScript1.m_jumpForce = 5.5f;
        playerScript1.m_moveSpeed = 4f;
        playerScript1.m_turnSpeed = 300f;
        Debug.Log("doet het");
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueGUI.SetActive(false);
        dialogueGUI_uitleg.SetActive(false);
        dialogueGUI_volgende.SetActive(false);
      
    }
}
