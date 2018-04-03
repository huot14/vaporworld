using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCamera : MonoBehaviour {

    public float xSpeed = 1f;
    public float ySpeed = 1f;
    public float zSpeed = 1f;

    Camera cam;
    Vector3 rotation;

    // Use this for initialization
    void Start ()
    {
        cam = GetComponent<Camera>();
        rotation = new Vector3(xSpeed, ySpeed, zSpeed);

    }
	
	// Update is called once per frame
	void Update ()
    {
        cam.transform.Rotate(rotation * Time.deltaTime);
	}
}
