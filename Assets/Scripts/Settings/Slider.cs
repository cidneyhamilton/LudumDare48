using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Clinic {

    // A slider with two buttons to toggle up and down
    public abstract class Slider : MonoBehaviour
    {

        public UnityEngine.UI.Slider slider;

        public virtual void Up() {
            if (slider != null) {
                slider.value = Mathf.Clamp(slider.value + 1f, slider.minValue, slider.maxValue); 
            }
        }

        public virtual void Down() {
            if (slider != null) {
                slider.value = Mathf.Clamp(slider.value - 1f, slider.minValue, slider.maxValue); 
            }
            
        }
    }

}
