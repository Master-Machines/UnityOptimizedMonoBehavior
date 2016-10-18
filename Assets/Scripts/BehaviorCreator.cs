using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BehaviorCreator : MonoBehaviour {
    public Text optimizedBehaviorCount;
    public Text regularBehaviorCount;
    
    private List<MonoBehaviour> standardBehaviors;
    private List<OptimizedBehavior> optimizedBehaviors;

    void Start () {
        Application.targetFrameRate = 300;
        standardBehaviors = new List<MonoBehaviour>();
        optimizedBehaviors = new List<OptimizedBehavior>();
        UpdateLabels();
	}

    public void CreateOptimizedBehaviors() {
        for(int i = 0; i < 5000; i++) {
            optimizedBehaviors.Add(gameObject.AddComponent<OptimizedBehavior>());
        }
        UpdateLabels();
    }

    public void CreateRegularBehaviors() {
        for(int i = 0; i < 5000; i++) {
            standardBehaviors.Add(gameObject.AddComponent<UnoptimizedBehavior>());
        }
        UpdateLabels();
    }

    public void ClearBehaviors() {
        StartCoroutine(SlowlyClearBehaviors());
    }

    IEnumerator SlowlyClearBehaviors() {
        int counter = 0;
        foreach(MonoBehaviour behavior in standardBehaviors) {
            Destroy(behavior);
            counter++;
            if(counter > 25) {
                counter = 0;
                yield return null;
            }
            
        }

        foreach(OptimizedBehavior behavior in optimizedBehaviors) {
            Destroy(behavior);
            counter++;
            if(counter > 25) {
                counter = 0;
                yield return null;
            }
        }
        standardBehaviors = new List<MonoBehaviour>();
        optimizedBehaviors = new List<OptimizedBehavior>();
        UpdateLabels();
    }

    void UpdateLabels() {
        optimizedBehaviorCount.text = "(" + optimizedBehaviors.Count + " active)";
        regularBehaviorCount.text = "(" + standardBehaviors.Count + " active)";
    }

}
