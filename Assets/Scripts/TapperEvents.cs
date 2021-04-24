using System;

namespace Cyborg.Clinic {
    
    public static class TapperEvents 
    {

	public static event Action OnStart;
	public static event Action OnEnd;

	public static void StartSequence() {
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
