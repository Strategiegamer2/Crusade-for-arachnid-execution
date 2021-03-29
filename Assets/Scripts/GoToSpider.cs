using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSpider : MonoBehaviour
{
    public GameObject dialogueGUI;
    public KeyCode DialogueInput = KeyCode.Return;
    public GameObject Player;
    public GameObject Spider;
    public GameObject Wall;

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

    private void DoSomething()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SimpleCharacterControl playerScript = Player.GetComponent<SimpleCharacterControl>();
            dialogueGUI.SetActive(false);
            playerScript.m_jumpForce = 5.5f;
            playerScript.m_moveSpeed = 4f;
            playerScript.m_turnSpeed = 300f;
            Wall.SetActive(false);
            Spider.SetActive(false);
        }
    }
}
