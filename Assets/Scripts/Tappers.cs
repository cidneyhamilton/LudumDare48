using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Dialogue;

namespace Cyborg.Clinic {

    public enum Tapper {
	Left,
	Right,
	None
	
    }

    public class Tappers : MonoBehaviour
    {
	
	void OnEnable() {
	    TapperEvents.OnStart += StartSequence;
	    TapperEvents.OnEnd += EndSequence;
	}

	void OnDisable() {
	    TapperEvents.OnStart -= StartSequence;
	    TapperEvents.OnEnd -= EndSequence;
	}
	
	private Tapper LastTapped = Tapper.None;
	private float timeRemaining = 10;
	private bool timerIsRunning = false;
	
	public int numTaps = 0;
	public int mistakes = 0;
	
	public void LeftTapper() {
	    Tap(Tapper.Left);
	}

	public void RightTapper() {
	    Tap(Tapper.Right);
	}

	public void Tap(Tapper tapper) {
	    if (LastTapped == tapper) {
		Debug.LogWarning("This tapper was tapped twice; rhythm is off!");
		mistakes++;
	    }
	    LastTapped = tapper;
	    numTaps++;
	}

	void Reset() {
	    numTaps = 0;
	    mistakes = 0;
	    LastTapped = Tapper.None;
	}

	void StartSequence() {
	    Reset();
	    GetComponent<Canvas>().enabled = true;
	    // TODO: Start a countdown timer to end the sequence
	    timerIsRunning = true;
	}

	void EndSequence() {
	    GetComponent<Canvas>().enabled = false;
	    Debug.Log("Sequence over.");	    

	    if (IsSuccess()) {
		StoryEvents.ChoosePath("success");
	    } else {
		StoryEvents.ChoosePath("failure");
	    }
	}

	// TODO: Scale the difficulty here
	bool IsSuccess() {
	    return numTaps > 10 && mistakes == 0;
	}	

	void Start() {
	    GetComponent<Canvas>().enabled = false;
	}

	void Update() {
	    if (timerIsRunning) {
		if (timeRemaining > 0) {
		    timeRemaining -= Time.deltaTime;
		} else {
		    timeRemaining = 0;
		    timerIsRunning = false;
		    EndSequence();
		}
	    }
	}
    }

}
