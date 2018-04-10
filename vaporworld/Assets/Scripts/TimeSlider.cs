using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour {

    Slider slider;
    public AudioSource source;

    bool updating = false;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        updating = true;

        slider.value = source.time / source.clip.length;

        updating = false;

	}

    public void drag()
    {
        if (!updating)
        {
            source.time = slider.value * source.clip.length;
        }
    }
}
