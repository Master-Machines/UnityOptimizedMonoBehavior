Created by Derek Schindhelm

Inspired by this blogpost from Unity: https://blogs.unity3d.com/2015/12/23/1k-update-calls/

This project highlights a custom version of the Unity MonoBehavior and a behavior manager. It shows off the performance improvements as well as the added code complexity that is needed.

The improvement's come in a CustomUpdate call. The call works in a similar way to the MonoBehavior's Update call, but it does it more efficiently. Unity's way of making the Update call is very safe, but it comes at a performance cost. In my testing, the framerate was doubled from 30 to 60 with 40,000 behaviors created.

There is added code complexity with the OptimizedBehavior class. For example, Awake() and OnDestroy() must be overriden by inherited classes and they must call base.Awake() and base.OnDestroy(). 

Is it worth it to create a custom behavior manager? I'd say it depends. If your game will have tens of thousands of MonoBehaviors, then the performance gains will definitely be worth it. But if you're only be working with hundreds or even a few thousand MonoBehaviors, I think it'd be best to stick with Unity's implementation.