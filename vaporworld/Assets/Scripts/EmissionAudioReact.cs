using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionAudioReact : AudioReact {

    public override void react(float sumOfTotals, float maxLevel) {
        Color colour = new Color();
        colour.r = sumOfTotals / maxLevel;
        colour.b = sumOfTotals / maxLevel;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", colour);
    }
}
