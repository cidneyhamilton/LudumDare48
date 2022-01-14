using System;
using UnityEngine;
using Cyborg.Audio;

namespace Cyborg.Clinic {
    
    public static class TapperEvents 
    {

								// Handles starting the tapper sequence
								public static event Action OnStart;

								// Handles ending the tapper sequence
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
