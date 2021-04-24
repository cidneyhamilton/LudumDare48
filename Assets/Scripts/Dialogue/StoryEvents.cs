using System;

namespace Cyborg.Dialogue {

    public static class StoryEvents 
    {
	public delegate void onSpeakEvent(string line);
	public static event onSpeakEvent OnSpeak;
	public static event onSpeakEvent OnChoosePath;
	
	public static event Action OnRestart;
	public static event Action OnContinue;
	public static event Action OnHide;

	// Show the Player Character's speech bubble
	public static void Speak(string line) {
	    // UnityEngine.Debug.Log("Speaking line " + line);
	    if (OnSpeak != null) {
		OnSpeak(line);
	    }
	}
	// Show the Player Character's speech bubble
	public static void ChoosePath(string knotName) {
	    if (OnChoosePath != null) {
		OnChoosePath(knotName);
	    }
	}
	
	// Restart the game
	public static void Restart() {
	    if (OnRestart != null) {
		OnRestart();
	    }
	}
       
	// Continue the dialogue
	public static void Continue() {
	    if (OnContinue != null) {
		OnContinue();
	    }
	}

	// Hide the UI
	public static void Hide() {
	    if (OnHide != null) {
		OnHide();
	    }
	}

    }
}
