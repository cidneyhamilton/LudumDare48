using UnityEngine;
using Cyborg.Audio;
using Cyborg.Dialogue;
using Cyborg.Scenes;

namespace Cyborg.Clinic {
    
    // Manages the buttons on the Start Screen
    public class TitleButtons : View {
	
        // Start a new game
        public void ClickStartGame() {
            PlayClick();
            StoryEvents.Hide();
            StoryEvents.Restart();
            SceneEvents.LoadMainScene();
        }

        // Open the Settings menu
        public void ClickSettings() {
            PlayClick();
            StoryEvents.ShowSettings();
            Time.timeScale = 0.0f;
        }

        // Quit the game
        public void ClickQuitGame() {
            PlayClick();
            // TODO: This will be ignored when in Play mode in the editor; come up with a workaround?
            Application.Quit();
        }

        // Always play the same audio event
        private void PlayClick() {
            AudioEvents.PlaySound("click");
        }
     
    }
}
