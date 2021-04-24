using UnityEngine;

using Cyborg.Audio;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace Cyborg.Clinic {
    
    public class StartButton : MonoBehaviour {

	
	public void StartGame() {
	    AudioEvents.PlaySound("click");
	    StoryEvents.Hide();
	    StoryEvents.Restart();
	    SceneEvents.ChangeScene("Main");
	}

	void Update() {
	    if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.KeypadEnter)) {
		StartGame();
	    }
	}
     
    }
}
