using UnityEngine;

using Cyborg.Audio;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace Cyborg.Clinic {
    
    public class MenuButton : View {

	void OnEnable() {
	    StoryEvents.OnShowSettings += Hide;
	    StoryEvents.OnHideSettings += Show;
	}

	void OnDisable() {
	    StoryEvents.OnShowSettings -= Hide;	
	    StoryEvents.OnHideSettings -= Show;
	}
	
	public void Settings() {
	    AudioEvents.PlaySound("click");
	    StoryEvents.ShowSettings();
	    Time.timeScale = 0.0f;
	}

	public void BackToTitle() {
	    AudioEvents.PlaySound("click");
	    SceneEvents.ChangeScene("_Title");
	}
     
    }
}
