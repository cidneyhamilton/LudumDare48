using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Audio;
using Cyborg.Dialogue;

namespace Cyborg.Clinic {

				// Handles the player's tappers
    public class Tappers : MonoBehaviour
    {

								// The music to play when tapping
								public TapperMusic TapperMusic;									
								public int numTaps = 0;
								public int mistakes = 0;
								
								private Tapper LastTapped = Tapper.None;
								private float timeRemaining = 10;
								private bool timerIsRunning = false;
								private float duration;

								const float START_DURATION = 8;
														
								void OnEnable() {
												TapperEvents.OnStart += StartSequence;
												TapperEvents.OnEnd += EndSequence;
												StoryEvents.OnRestart += ResetDuration;
								}

								void OnDisable() {
												TapperEvents.OnStart -= StartSequence;
												TapperEvents.OnEnd -= EndSequence;
												StoryEvents.OnRestart -= ResetDuration;
								}
	
								public void LeftTapper() {
												if (timerIsRunning) {
																AudioEvents.PlaySound("tap1");
																Tap(Tapper.Left);
												}
								}

								public void RightTapper() {
												if (timerIsRunning) {
																AudioEvents.PlaySound("tap2");
																Tap(Tapper.Right);
												}
								}

								public void Tap(Tapper tapper) {
												if (LastTapped == tapper) {
																Debug.LogWarning("This tapper was tapped twice; rhythm is off!");
																mistakes++;
																EndEarly();
												} else {
																StoryEvents.ShowHallucination();
												}
												LastTapped = tapper;
												numTaps++;
								}

								void Reset() {
												numTaps = 0;
												mistakes = 0;
												LastTapped = Tapper.None;
								}

								void ResetDuration() {
												duration = START_DURATION;
								}
	
								void StartSequence() {
												// Debug.Log("starting tapper sequence.");
												Reset();
												GetComponent<Canvas>().enabled = true;
												AudioEvents.FadeOutMusic();
												TapperMusic.FadeInMusic();
												// Start a countdown timer to end the sequence
												timerIsRunning = true;
												timeRemaining = duration;
								}

								void EndEarly() {
												timeRemaining = 0;
												timerIsRunning = false;
												EndSequence();
								}
	
								void EndSequence() {
												GetComponent<Canvas>().enabled = false;
												Debug.Log("Sequence over.");	    

												if (IsSuccess()) {
																duration += 2;
																AudioEvents.PlaySound("HappySting");
																AudioEvents.PlayMusic("Main");	    
																AudioEvents.FadeInMusic();
																TapperMusic.FadeOutMusic();		
																StoryEvents.ChoosePath("success");
												} else {
																AudioEvents.PlaySound("FailureSting");
																StoryEvents.ChoosePath("failure");
												}
								}

								// TODO: Scale the difficulty here
								bool IsSuccess() {
												return numTaps >= duration && mistakes == 0;
								}	

								void Start() {
												GetComponent<Canvas>().enabled = false;
												ResetDuration();
								}

								void Update() {
												if (timerIsRunning) {															
																Countdown();
																HandleInput();
												}
								}

								// Count down the timer; when out of time, end the sequence
								void Countdown() {
												if (timeRemaining > 0) {
																timeRemaining -= Time.deltaTime;
												} else {
																timeRemaining = 0;
																timerIsRunning = false;
																EndSequence();
												}
								}

								// Listen for and handle keyboard input
								void HandleInput() {												
												if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightControl)) {
																LeftTapper();
												}
												if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftControl)) {
																RightTapper();
												}		
								}

    }

}
