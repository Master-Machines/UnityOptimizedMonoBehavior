using UnityEngine;
using System.Collections;

/// <summary>
/// Optmized version of MonoBehavior that uses a more efficient method for update calls. 
/// Classes can inherit from OptmizedBehavior and still retain all of the functionality of MonoBehavior
/// </summary>
public class OptimizedBehavior : MonoBehaviour {

    protected virtual void Awake() {
        OptimizedBehaviorManager.AddBehavior(this);
    }

    // Override this method to access a more efficient version of Update()
	public virtual void CustomUpdate () {}
    
    protected virtual void OnDestroy() {
        OptimizedBehaviorManager.RemoveBehavior(this);
    }
}
