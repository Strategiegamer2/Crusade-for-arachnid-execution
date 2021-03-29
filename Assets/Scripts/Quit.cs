using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject quitCanvas;
    bool escape = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escape == false)
        {
            quitCanvas.SetActive(true);
            escape = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escape == true)
        {
            quitCanvas.SetActive(false);
            escape = false;
        }
    }

    public void yes()
    {
        Application.Quit();
    }

    public void no()
    {
        quitCanvas.SetActive(false);
        escape = false;
    }
}
