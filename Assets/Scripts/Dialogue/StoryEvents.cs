using System;
using System.Collections.Generic;

namespace Cyborg.Dialogue {

    public static class StoryEvents 
    {
	public delegate void OnSpeakEvent(string line, List<string> tags);
	public static event OnSpeakEvent OnSpeak;

	public delegate void OnPathEvent(string knotName);
	public static event OnPathEvent OnChoosePath;
	
	public static event Action OnRestart;
	public static event Action OnContinue;
	public static event Action OnHide;

	// Show the Player Character's speech bubble
	public static void Speak(string line, List<string> tags) {
	    // UnityEngine.Debug.Log("Speaking line " + line);
	    if (OnSpeak != null) {
		OnSpeak(line, tags);
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
