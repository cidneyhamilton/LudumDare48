using UnityEngine;

using Cyborg.Audio;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace Cyborg.Clinic {
    
    public class StartButton : MonoBehaviour {

	bool isStarting;

	public void Start() {
	    isStarting = false;
	}
	
	public void StartGame() {
	    if (!isStarting) {
		isStarting = true;
		AudioEvents.PlaySound("click");
		StoryEvents.Hide();
		StoryEvents.Restart();
		SceneEvents.ChangeScene("Main");
	    }
	}

	void Update() {
	    if (Input.GetKeyUp("space") || Input.GetKeyUp("enter")) {
		StartGame();
	    }
	}
     
    }
}
