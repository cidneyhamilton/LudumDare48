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
            PlayClick();
            StoryEvents.ShowSettings();
            Time.timeScale = 0.0f;
        }

        public void BackToTitle() {
            PlayClick();
            SceneEvents.LoadTitleScene();
        }

        // Always play the same audio event
        private void PlayClick() {
            AudioEvents.PlaySound("click");
        }
     
    }
}
