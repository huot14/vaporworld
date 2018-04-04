using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReact : MonoBehaviour {

    public AudioAnalyzer analyzer; // Link analyzer script from parent object
    public float maxLevel; // Max total sum of the spectrum range

    public int rangeStart;
    public int rangeEnd;

    public Queue<float> movingAverage; // Each index corresponds to the rangeTotal at a period of time
    public int movingAverageWidth;

    // Use this for initialization
    void Start() {
        movingAverage = new Queue<float>();
    }

    // Update is called once per frame
    void Update() {
        float[] currSpectrum = analyzer.getSpectrum();

        float rangeTotal = 0;

        // Sum total of values in desired range
        for (int i = rangeStart; i < rangeEnd; i++) {
            rangeTotal += Mathf.Clamp((50+i*i) * currSpectrum[i],0,50);
        }

        // Update moving average with current value
        updateMovingAverage(rangeTotal);

        // Take the total of the current moving average
        float sumOfTotals = sumQueue(movingAverage);

        if (sumOfTotals > maxLevel) { sumOfTotals = maxLevel; }

        react(sumOfTotals, maxLevel);
    }

    // Adjust position based on given value
    public virtual void react(float sumOfTotals, float maxLevel) {

    }

    void updateMovingAverage(float newValue) {
        movingAverage.Enqueue(newValue);

        if (movingAverage.Count > movingAverageWidth) {
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
