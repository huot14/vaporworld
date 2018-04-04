using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyzer : MonoBehaviour {

    public AudioSource audioSource;
    private float[] samples; // Wil hold our sample data
    private float currDB;
    private float[] currSpectrum;

    void Start () {
        samples = new float[1024]; // Allocate 1024 samples
        currSpectrum = new float[64];
    }
	
	void Update () {
        audioSource.GetOutputData(samples, 0);
        currDB = convertToDB(samples);
        currSpectrum = getSpectrum(audioSource);
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

    private float[] getSpectrum(AudioSource source) {
        float[] spectrum = new float[64];

        source.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        return spectrum;
    }

    public float getDB() {
        return currDB;
    }

    public float[] getSpectrum() {
        return currSpectrum;
    }
}
