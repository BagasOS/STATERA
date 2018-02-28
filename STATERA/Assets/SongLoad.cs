using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using System.IO;

using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters;

using System.Runtime.Serialization.Formatters.Binary;

using System.Collections.Generic;

public class SongLoad : MonoBehaviour {
	
	private GameObject[] buttons;
	public AudioSource audio;
	private List<float> music = new List<float>();
	private float startTime;
	private bool start = false;
	private int iMusic = 0;
	private LevelManager levelManager;
	private SongLibrary library;
	
	void Start () {
		Time.timeScale = 1.0f;
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager> ();
		library = GameObject.FindGameObjectWithTag ("SongLibrary").GetComponent<SongLibrary> ();
		LoadFromLibrary ();
		buttons = levelManager.Levels [levelManager.CurrentLevel].ElementButtons;
		audio.clip = levelManager.Levels[levelManager.CurrentLevel].MusicClip;
		ScoreManager.instance.AssignNotesCount(music.Count);
	}
	
	void Update () {
		
		if(start && iMusic < music.Count && Time.time - startTime  + 1.4f >= music[iMusic])
		{
			iMusic++;
			if(iMusic == music.Count)
			{
				GameOverManager.instance.Win();
			}
			Instantiate(buttons[Random.RandomRange(0, buttons.Length)], transform.position, transform.rotation);
		}
	}

	public void Load()
	{
		
		ElementEmblemSong charData = new ElementEmblemSong();
		
		Stream stream = File.Open(levelManager.Levels[levelManager.CurrentLevel].Filename, FileMode.Open);
		
		BinaryFormatter bformatter = new BinaryFormatter();
		
		UnityEngine.Debug.Log("Loading variables");
		
		charData = (ElementEmblemSong)bformatter.Deserialize(stream);
		
		music = charData.music;
		
		stream.Close();
	}

	public void LoadFromLibrary()
	{
		music = library.Beatmaps [levelManager.CurrentLevel].music;
	}

	public void PlayLevel()
	{
		audio.Play();
		startTime = Time.time;
		start = true;
	}
}
