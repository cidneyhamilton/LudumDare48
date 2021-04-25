using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Audio;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace Cyborg.Clinic {
    
    public class SettingsView : View
    {

	
	void OnEnable() {
	    StoryEvents.OnShowSettings += Show;
	}

	void OnDisable() {
	    StoryEvents.OnShowSettings -= Show;
	}

	void Start() {
	    Hide();
	}
	
	public void Back() {
	    AudioEvents.PlaySound("click");
	    Hide();
	    StoryEvents.HideSettings();
	    Time.timeScale = 1.0f;
	}
    }
}
