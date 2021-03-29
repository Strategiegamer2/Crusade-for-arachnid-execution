using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float speedH = 4.0f;
    public float speedV = 4.0f;
    public float speedG = 0.5f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * speedG);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * speedG);
        }
    }
}
