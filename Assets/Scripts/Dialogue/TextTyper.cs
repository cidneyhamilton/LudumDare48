using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.UI;

namespace Cyborg.Dialogue {

    // Text typing effect on text boxes
    [RequireComponent (typeof (Text))]
    public class TextTyper : MonoBehaviour
    {

        private Font font { get; set; }

        private float startDelay = 0f;

        // The text to type out
        private Text textComponent;
			
        private bool typing = false;
        private int counter = 0;

        private string[] lettersToType;

        private int wordIndex;
        private string[] words;
        private string textToType;

        private float currentLineWidth;
        
        void Awake() {
            textComponent = GetComponent<Text>();
            font = textComponent.font;
	}

        public void UpdateText(string newText) {
            // Debug.Log(string.Format("Updating text to {0}", newText));
	    StopTyping();
	    textComponent.text = "";
	    textToType = newText;
	    lettersToType = Regex.Split(textToType, string.Empty);
	    words = textToType.Split(' ');
	    StartTyping();    
        }

        public void Continue() {
            textComponent.text = textToType;
            StopTyping();
        }

        public bool IsTyping() {
            return typing;
        }

        void StartTyping() {
            if (typing) {
                // Already typing; do nothing!
            } else {
	      InvokeRepeating("Type", startDelay, 0.08f);
            }
        }
				
        void StopTyping() {
            currentLineWidth = 0;
            counter = 0;
            wordIndex = 0;
            typing = false;
            CancelInvoke("Type");
        }

	float GetContainerWidth() {
	    // Debug.Log("Container width: " + GetComponent<RectTransform>().sizeDelta.x);
	    return Mathf.Max(300f, GetComponent<RectTransform>().sizeDelta.x * 1f - 20f);     
	}
	
	
        // Returns a normalised percentage (0-1) of how much space a character takes on a line of text
        float GetWidth(char c)
        {
            // TODO We should create a proper lookup table for each letter, rather than referencing at runtime

            CharacterInfo ch;
	    font.RequestCharactersInTexture(c.ToString(), textComponent.fontSize); 
	    font.GetCharacterInfo(c, out ch);
	    
	    //Debug.Log(string.Format("Width of character {0}: {1}", c, ch.glyphWidth));
			
	    //Debug.Log("Width of container: " + GetContainerWidth());
	    return ch.glyphWidth / GetContainerWidth();;
        }
		
        void Type() {

            if (counter == lettersToType.Length) {
                StopTyping();
            } else {
                typing = true;

                string nextLetter = lettersToType[counter];

                if (nextLetter.Length > 0)
                {
                    currentLineWidth += GetWidth(nextLetter[0]);
                }
                if (nextLetter==" ") // A new word has appeared!
                {
                    wordIndex++;

                    var wordlength = 0f;
                    foreach (var w in words[wordIndex])
                    {
                        wordlength += GetWidth(w);
                    }
                }
                if (nextLetter == "/r/n" || nextLetter == "/n")
                {
                    Debug.Log("Encountered Natural Newline!");
                    currentLineWidth = 0;
                }

                // TODO: Handle Rich Text Tags a bit more elegantly
                if (nextLetter == "<") {		    
		    Debug.Log("Encountered rich text tag; show the whole word.");

		    // Next letter
		    counter++;
		    nextLetter += lettersToType[counter];
		    
		    // Go to the next tag
		    while (lettersToType[counter] != "<") {
			counter++;
			nextLetter += lettersToType[counter];
		    }

		    // Next Letter
		    counter++;
		    nextLetter += lettersToType[counter];

		    
		    // Go to the end of the next tag
		    while (lettersToType[counter] != ">") {
			counter++;
			nextLetter += lettersToType[counter];
		    }
                }

		// Add to text component
                textComponent.text = textComponent.text + nextLetter; 
		counter++;    
            }
            
        }
    }

}
