using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreqSpectrumDisplay : AudioReact {

    public override void react(float sumOfTotals, float maxLevel) {
        float currX = GetComponent<RectTransform>().localPosition.x;
        GetComponent<RectTransform>().localPosition = new Vector3(currX, 106 + (sumOfTotals/maxLevel)*30, 0);
    }
}
