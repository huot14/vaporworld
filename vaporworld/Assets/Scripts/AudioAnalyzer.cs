using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyzer : MonoBehaviour {

    public AudioSource audioSource;
    private float[] samples; // Wil hold our sample data
    private float currDB;


    void Start () {
        samples = new float[1024]; // Allocate 1024 samples
    }
	
	void Update () {
        audioSource.GetOutputData(samples, 0);
        currDB = convertToDB(samples);
    }

    private float convertToDB(float[] samples) {

        float sumSquares = 0;

        foreach (float sample in samples) {
            sumSquares += sample * sample; //sample^2
        }

        // Calculate db -> 20*Log10(rms/ref)
        // ref is just 1 here, so:
        float db = 20 * Mathf.Log10(sumSquares);

        return db;
    }

    public float getDB() {
        return currDB;
    }
}
