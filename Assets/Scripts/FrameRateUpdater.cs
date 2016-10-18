using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FrameRateUpdater : OptimizedBehavior {
    public Text frameRateLabel;

    private const int numberOfFramesToTrack = 60;
    private Queue<float> deltaTimeValues;
    private float runningTotal = 0f;
    
    protected override void Awake() {
        base.Awake();
        deltaTimeValues = new Queue<float>();
    }

	public override void CustomUpdate () {
        deltaTimeValues.Enqueue(Time.deltaTime);
        runningTotal += Time.deltaTime;
        if (deltaTimeValues.Count > numberOfFramesToTrack) {
            runningTotal -= deltaTimeValues.Dequeue();
            int frameRate = (int)((float)numberOfFramesToTrack / runningTotal);
            frameRateLabel.text = frameRate.ToString();
        }
	}
}
