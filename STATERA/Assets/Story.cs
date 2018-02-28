using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class Story : MonoBehaviour {

	public GameObject StoryPanel;
	public SongLoad Songload;

	void Start () {
		GetComponent<TapGesture>().Tapped += HandleTapped;
	}

	void HandleTapped (object sender, System.EventArgs e)
	{
		Skip ();
	}

	void Update () {
	
	}

	void Skip()
	{
		StoryPanel.SetActive (false);
		Songload.PlayLevel ();
		gameObject.SetActive (false);
	}
}
