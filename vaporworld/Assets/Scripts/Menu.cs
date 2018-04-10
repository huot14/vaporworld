using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button start;
    public Button quit;

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = true;
        start.onClick.AddListener(startBtn);
        quit.onClick.AddListener(quitBtn);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void startBtn()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("TheWorld");
    }

    void quitBtn()
    {
        Application.Quit();
    }


}
