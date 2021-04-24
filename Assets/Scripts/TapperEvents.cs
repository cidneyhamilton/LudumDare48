using System;
using UnityEngine;

namespace Cyborg.Clinic {
    
    public static class TapperEvents 
    {

	public static event Action OnStart;
	public static event Action OnEnd;

	public static void StartSequence() {
	    Debug.Log("Starting tapper sequence.");
	    if (OnStart != null) {
		OnStart();
	    }
	}

	public static void EndSequence() {
	    if (OnEnd != null) {
		OnEnd();
	    }
	}
    }
}
