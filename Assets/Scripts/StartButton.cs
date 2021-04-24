using UnityEngine;

using Cyborg.Audio;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace Cyborg.Clinic {
    
    public class StartButton : MonoBehaviour {
	
	public void StartGame() {
	    StoryEvents.Restart();
	    SceneEvents.ChangeScene("Main");
	}
    }
}
