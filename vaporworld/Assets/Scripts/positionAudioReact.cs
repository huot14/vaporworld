using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionAudioReact : MonoBehaviour {
    public AudioAnalyzer analyzer; // Link analyzer script from parent object
    public float minHeight;
    public float maxHeight;
    public float maxDB;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float currDB = analyzer.getDB();

        if (currDB > maxDB) { currDB = maxDB; }

        this.transform.position = new Vector3(this.transform.position.x, maxHeight * (currDB/ maxDB), this.transform.position.z);
	}
}
