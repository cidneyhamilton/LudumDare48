using System;
using System.Collections.Generic;

namespace Cyborg.Dialogue {

    public static class StoryEvents 
    {
	public delegate void OnSpeakEvent(string speaker, string speech, List<string> tags);
	public static event OnSpeakEvent OnSpeak;

	public delegate void OnPathEvent(string knotName);
	public static event OnPathEvent OnChoosePath;
	
	public static event Action OnRestart;
	public static event Action OnContinue;
	public static event Action OnHide;

	public static event Action OnShowSettings;
	
	// Show the Player Character's speech bubble
	public static void Speak(string speaker, string speech, List<string> tags) {
	    // UnityEngine.Debug.Log("Speaking line " + line);
	    if (OnSpeak != null) {
		OnSpeak(speaker, speech, tags);
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

	public static void ShowSettings() {
	    if (OnShowSettings != null) {
		OnShowSettings();
	    }
	}

    }
}
