using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	[System.Serializable]
	public enum Design { Air, Api, Kayu, Logam, Tanah };

	[System.Serializable]
	public class ElementEmblemLevel
	{
		public string Filename;
		public AudioClip MusicClip;
		public GameObject[] ElementButtons;
		public Design LevelDesign;
		public Sprite StoryBG;
		public string StoryText;
	}

	public ElementEmblemLevel[] Levels;
	public int CurrentLevel;
	
	void Start () {
		Time.timeScale = 1.0f;
		DontDestroyOnLoad (this.gameObject);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	void Update () {
	
	}



	public void OpenPanel(GameObject panel)
	{
		panel.SetActive (true);
	}
}
