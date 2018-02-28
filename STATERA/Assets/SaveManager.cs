using UnityEngine;

using System.Collections;

using System.IO;

using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters;

using System.Runtime.Serialization.Formatters.Binary;

using System.Collections.Generic;



[System.Serializable]

public class ElementEmblemSong
{
	
	public List<float> music = new List<float>();
	
	public ElementEmblemSong()
	{
		music.Clear();
	}
}



public class SaveManager : MonoBehaviour
{
	public string Filename;
	public AudioClip MusicClip;
	public List<float> music = new List<float>();
	private AudioSource audioSource;

	public void Save()
	{
		music = music1;
		
		ElementEmblemSong charData = new ElementEmblemSong();
		
		charData.music = music;
		
		Stream stream = File.Open(Filename, FileMode.Create);
		
		BinaryFormatter bformatter = new BinaryFormatter();
		
		bformatter.Serialize(stream, charData);
		
		stream.Close();
		
	}
	
	public void Load()
	{
		
		ElementEmblemSong charData = new ElementEmblemSong();
		
		Stream stream = File.Open(Filename, FileMode.Open);
		
		BinaryFormatter bformatter = new BinaryFormatter();
		
		UnityEngine.Debug.Log("Loading variables");
		
		charData = (ElementEmblemSong)bformatter.Deserialize(stream);
		
		music = charData.music;
		
		stream.Close();
		
	}
	
	private float startTime;
	private bool starting = false;
	private List<float> music1 = new List<float>();
	
	void Start()
	{
		audioSource = Camera.main.GetComponent<AudioSource> ();

		Stream stream = File.Open(Filename, FileMode.Open);
		if (stream != null)
			Debug.LogError ("Filename already exist!");
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F1) && !starting)
		{
			audioSource.clip = MusicClip;
			audioSource.Play();
			startTime = Time.time;
			starting = true;
			Debug.Log("Recording!");
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			music1.Add(Time.time - startTime);
		}
		
		if(Input.GetKeyDown(KeyCode.F2))
		{
			audioSource.Stop();
			music1.Add(Time.time - startTime);
			Save();
			Debug.Log("File saved with name : " + Filename);
		}
	}
	
}