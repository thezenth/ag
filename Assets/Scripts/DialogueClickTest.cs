using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueClickTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		Character c = GetComponent<Character>();
		StartCoroutine( c.speak("Hello world!", 5.0f) );
	}
}
