using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp_ShowSword : MonoBehaviour
{
    public GameObject dialogueGUI;
    public KeyCode DialogueInput = KeyCode.Return;
    public GameObject Player;


    void Start()
    {


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("werkt");
            GameObject Player = GameObject.Find("Player");
            SimpleCharacterControl playerScript = Player.GetComponent<SimpleCharacterControl>();
            playerScript.m_jumpForce = 0f;
            playerScript.m_moveSpeed = 0f;
            playerScript.m_turnSpeed = 0f;
            dialogueGUI.SetActive(true);
            DoSomething();
            Debug.Log("werkt1");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dialogueGUI.SetActive(false);
    }

    private void DoSomething()
    {

        Debug.Log("werkt2");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Dialog_Plane");
            Debug.Log("Dialogue started");
        }
    }
}
