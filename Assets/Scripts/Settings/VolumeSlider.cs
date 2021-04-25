using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Cyborg.Audio;

namespace Cyborg.Clinic {

    // Slider to adjust the in-game volume
    public class VolumeSlider : Slider
    {

        const float SCALE_FACTOR = 10f;
        public AudioMixer volumeMixer;
	const string VOLUME = "volume";
	float mixerVolume;
	
        void Start()
        {
	    
	    volumeMixer.GetFloat(VOLUME, out mixerVolume);
            slider.value = VolumeToSliderValue(mixerVolume);
        }

	private float VolumeToSliderValue(float volume) {
	    return Mathf.Pow(10, volume/20);
	}

	private float SliderValueToVolume(float value) {
	    return Mathf.Log10(value) * 20;
	}
	
        public void UpdateSlider() {
            if (slider != null) {
                volumeMixer.SetFloat(VOLUME, SliderValueToVolume(slider.value));
            }
        }

        public override void Up() {
            base.Up();
            UpdateSlider();

            AudioEvents.PlaySound("click");
        }

        public override void Down() {
            base.Down();
            UpdateSlider();

	    AudioEvents.PlaySound("click");            
        }
    }

}
