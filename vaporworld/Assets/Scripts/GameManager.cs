using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    float timePassed = 0f;

    public Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
