using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    Transform cat;
    public float speed = 3.0f;

    public float distance = 50.0f;
    float moved = 0.0f;

    bool move = true;
    bool forward = true;

	// Use this for initialization
	void Start ()
    {
        cat = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (forward && moved < distance)
        {
            Vector3 move = cat.forward * Time.deltaTime * speed;
            cat.Translate(move);
            moved += Vector3.Magnitude(move);
        }
        else if(forward && moved >= distance)
        {
            forward = false;
        }

        if(!forward && moved > -distance)
        {
            Vector3 move = -cat.forward * Time.deltaTime * speed;
            cat.Translate(move);
            moved -= Vector3.Magnitude(move);
        }
        else if(!forward && moved <= -distance)
        {
            forward = true;
        }
	}
}
