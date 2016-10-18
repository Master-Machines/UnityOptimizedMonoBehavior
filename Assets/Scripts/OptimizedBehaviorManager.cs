using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OptimizedBehaviorManager : MonoBehaviour {
    static List<OptimizedBehavior> behaviors;

	void Awake () {
        DontDestroyOnLoad(this);
        EnsureInitialized();
    }
	
	void Update () {
	    foreach(OptimizedBehavior behavior in behaviors) {
            behavior.CustomUpdate();
        }
	}

    private static void EnsureInitialized() {
        if (behaviors == null) {
            behaviors = new List<OptimizedBehavior>();
        }
    }

    public static void AddBehavior(OptimizedBehavior behavior) {
        EnsureInitialized();
        behaviors.Add(behavior);
    }

    public static void RemoveBehavior(OptimizedBehavior behavior) {
        EnsureInitialized();
        behaviors.Remove(behavior);
    }
}
