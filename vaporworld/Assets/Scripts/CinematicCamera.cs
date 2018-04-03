using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamera : MonoBehaviour {

    Camera cam;
    float fov;

    public bool fovMode;
    public bool moveMode;

    public float moveSpeed = 1.0f;
    public Vector3 pos1;
    public Vector3 pos2;

    public float fovSpeed = 1.0f;
    public float fovMin = 1;
    public float fovMax = 170;

    bool increaseFov = true;


	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
        fov = cam.fieldOfView;

	}

    // Update is called once per frame
    void Update()
    {
        if (fovMode)    // Change the field of view between fovMin and fovMax
        { 

            if (fov < fovMax && increaseFov)
            {
                fov += fovSpeed * Time.deltaTime;
                cam.fieldOfView = fov;

                if (fov >= fovMax)
                {
                    increaseFov = false;
                }
            }
            else if (fov >= fovMin && !increaseFov)
            {
                fov -= fovSpeed * Time.deltaTime;
                cam.fieldOfView = fov;

                if (fov <= fovMin)
                {
                    increaseFov = true;
                }
            }
        }

        if (moveMode)    // Change the position between pos1 and pos2
        {
            //TODO
        }


    }
}
