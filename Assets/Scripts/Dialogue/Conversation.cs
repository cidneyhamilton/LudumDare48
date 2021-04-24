using System.Collections.Generic;
using Cyborg.Clinic;
using UnityEngine;

namespace Cyborg.Dialogue {

    public class Conversation : View
    {
	// Views for dialogue
	public SpeechView SpeechView;
	public bool canContinue;
	
	private static float timer;
	const float INPUT_DEBOUNCE = 0.4f;
	
	void Update() {
	    // Update the timer for the debounce effect	    
	    timer += Time.deltaTime;   	    
	}
	
	void OnEnable() {
	    StoryEvents.OnSpeak += Speak;
	}

	void OnDisable() {	    
	    StoryEvents.OnSpeak -= Speak;
	}
	
	public void Continue() {
	    if (timer < INPUT_DEBOUNCE) {
		// Don't advance
		// Debug.Log("Don't advance.");
	    } else if (IsTyping()) {
		// Debug.Log("Finish typing.");
		FinishTyping();
	    } else if (canContinue) {
		// Debug.Log("Continue story.");
		timer = 0;
		StoryEvents.Continue();
	    }
	}
	
	// Checks to see if any of these are typing
	public bool IsTyping() {
	    return SpeechView.IsTyping();
	}

	public void FinishTyping() {
	    if (SpeechView.IsTyping()) {
		SpeechView.FinishTyping();
	    } 
	}

	void Speak(string speaker, string line, List<string> tags) {
	    Debug.Log("Speaking line " + line + ",  setting canContinue.");
	    canContinue = true;
	    timer = 0;

	}	

    }

}
