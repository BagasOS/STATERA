using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class testtap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += HandleTapped;
		Debug.Log ("Enable");
	}

	void HandleTapped (object sender, System.EventArgs e)
	{
		Debug.Log ("Tapped");
	}
}
