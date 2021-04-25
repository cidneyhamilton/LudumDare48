using UnityEngine;

using Cyborg.Audio;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace Cyborg.Clinic {
    
    public class StartButton : View {
	
	public void StartGame() {
	    AudioEvents.PlaySound("click");
	    StoryEvents.Hide();
	    StoryEvents.Restart();
	    SceneEvents.ChangeScene("Main");
	}

	public void Settings() {
	    AudioEvents.PlaySound("click");
	    StoryEvents.ShowSettings();
	    Time.timeScale = 0.0f;
	}
     
    }
}
