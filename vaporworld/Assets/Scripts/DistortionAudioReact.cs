using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionAudioReact : AudioReact {

    public override void react(float sumOfTotals, float maxLevel) {
        GetComponent<Renderer>().material.SetFloat("_BumpAmt", (sumOfTotals/maxLevel)*128);
    }
}
