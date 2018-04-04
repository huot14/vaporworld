using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject fpsController;
    public GameObject[] cameras;
    public float minWait = 5f;
    public float maxWait = 20f;

    int current = 0;    //current enabled camera

    float waitTime;
    float timePassed = 0f;

    public bool cinematicMode = true;

	// Use this for initialization
	void Start ()
    {
        waitTime = Random.Range(minWait, maxWait);

        for(int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        fpsController.SetActive(false);


        if (cinematicMode)
        {
            cameras[current].SetActive(true);
        }
        else
        {
            fpsController.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cinematicMode)
        {
            if (timePassed < waitTime)
            {
                timePassed += Time.deltaTime;
            }
            else
            {
                cameraSwitch();
                timePassed = 0f;
                waitTime = Random.Range(minWait, maxWait);
            }

			if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				cameraSwitch();
				timePassed = 0f;
				waitTime = Random.Range(minWait, maxWait);
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				cameraSwitchBack();
				timePassed = 0f;
				waitTime = Random.Range(minWait, maxWait);
			}
        }
        
        if(Input.GetKeyDown(KeyCode.C))
        {
            cinematicMode = !cinematicMode;

            if (cinematicMode)
            {
                fpsController.SetActive(false);
            }
            else
            {
                fpsController.SetActive(true);
            }
        }
	}

    void cameraSwitch()
    {
        if(current < cameras.Length)
        {
            cameras[current].SetActive(false);
            current++;
        }
        if(current >= cameras.Length)
        {
            current = 0;
        }

        if (cinematicMode)
        {
            cameras[current].SetActive(true);
        }
    }

	void cameraSwitchBack()
	{
		if(current < cameras.Length)
		{
			cameras[current].SetActive(false);
			current--;
		}
		if(current <= 0)
		{
			current = cameras.Length - 1;
		}

		if (cinematicMode)
		{
			cameras[current].SetActive(true);
		}
	}
}
