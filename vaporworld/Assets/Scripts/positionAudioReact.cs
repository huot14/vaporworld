﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionAudioReact : MonoBehaviour {
    public AudioAnalyzer analyzer; // Link analyzer script from parent object
    public float minHeight;
    public float maxHeight;
    public float maxLevel; // Max total sum of the spectrum range

    public int rangeStart;
    public int rangeEnd;

    public Queue<float> movingAverage; // Each index corresponds to the rangeTotal at a period of time
    public int movingAverageWidth;

	// Use this for initialization
	void Start () {
        movingAverage = new Queue<float>();
	}
	
	// Update is called once per frame
	void Update () {
        float[] currSpectrum = analyzer.getSpectrum();

        float rangeTotal = 0;

        // Sum total of values in desired range
        for (int i  = rangeStart; i < rangeEnd; i++) {
            rangeTotal += currSpectrum[i];
        }

        // Update moving average with current value
        updateMovingAverage(rangeTotal);

        // Take the total of the current moving average
        float sumOfTotals = sumQueue(movingAverage);

        if (sumOfTotals > maxLevel) { sumOfTotals = maxLevel; }

        reactPosition(sumOfTotals, maxLevel);
    }

    // Adjust position based on given value
    void reactPosition(float sumOfTotals, float maxLevel) {
        this.transform.position = new Vector3(this.transform.position.x, maxHeight * (sumOfTotals / maxLevel), this.transform.position.z);
    }

    void updateMovingAverage(float newValue) {
        movingAverage.Enqueue(newValue);
        
        if (movingAverage.Count > movingAverageWidth){
            movingAverage.Dequeue();
        }
    }

    // Sums all values in a queue
    float sumQueue(Queue<float> queue) {
        float sum = 0;

        float[] queueValues = queue.ToArray();

        foreach (float value in queueValues) {
            sum += value;
        }

        return sum;
    }
}
