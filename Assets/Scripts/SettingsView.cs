using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Audio;
using Cyborg.Dialogue;

namespace Cyborg.Clinic {
    
    public class SettingsView : View
    {

	void OnEnable() {
	    Hide();
	    StoryEvents.OnShowSettings += Show;
	}

	void OnDisable() {
	    StoryEvents.OnShowSettings -= Hide;
	}
	
	public void Back() {
	    AudioEvents.PlaySound("click");
	    Hide();
	}
    }
}
