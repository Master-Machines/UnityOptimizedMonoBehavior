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
        CreateBehaviors(true);
    }

    public void CreateRegularBehaviors() {
        CreateBehaviors(false);
    }

    private void CreateBehaviors(bool isOptimized) {
        for(int i = 0; i < 5000; i++) {
            if(isOptimized)
                optimizedBehaviors.Add(gameObject.AddComponent<OptimizedBehavior>());
            else
                standardBehaviors.Add(gameObject.AddComponent<UnoptimizedBehavior>());
        }
        UpdateLabels();
    }

    public void ClearBehaviors() {
        StartCoroutine(SlowlyClearBehaviors());
    }

    // Slowly Destroy the behaviors to prevent the app from seeming like it crashed.
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
        /** This method gets called very rarely. If it was called more frequently, 
         *  it would be good to use a string builder or a different method to avoid all of the string concatenation here, 
         *  as each concatenation creates garbage for the collector */
        optimizedBehaviorCount.text = "(" + optimizedBehaviors.Count + " active)";
        regularBehaviorCount.text = "(" + standardBehaviors.Count + " active)";
    }

}
