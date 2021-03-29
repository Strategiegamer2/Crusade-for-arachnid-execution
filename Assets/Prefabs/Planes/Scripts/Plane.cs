using UnityEngine;
using System.Collections;

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //

public class Plane : MonoBehaviour {
	public GameObject prop;
	public GameObject propBlured;
    public float thrust;
    public Rigidbody rb;

    public bool engenOn;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update () 
	{
		if (engenOn) {
			prop.SetActive (false);
			propBlured.SetActive (true);
			propBlured.transform.Rotate (1000 * Time.deltaTime, 0, 0);
		} else {
			prop.SetActive (true);
			propBlured.SetActive (false);
		}

        rb.AddForce(Vector3.back * thrust);
    }
}

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //