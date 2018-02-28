using UnityEngine;

using System.Collections;

using System.IO;

using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters;

using System.Runtime.Serialization.Formatters.Binary;

using System.Collections.Generic;

//using UnityEditor;


public class SongLibrary : MonoBehaviour {
	
	public List<ElementEmblemSong> Beatmaps = new List<ElementEmblemSong>();
	//public LevelManager GM;
	
	void Start()
	{
		DontDestroyOnLoad (gameObject);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
//		for(int i = 0; i < 20; i++)
//		{
//		    Load(GM.Levels[i].Filename);
//		}
//		PrefabUtility.CreatePrefab("Assets/SongLibrary.prefab", gameObject);
	}
	
	public void Load(string Filename)
	{
		
		ElementEmblemSong charData = new ElementEmblemSong();
		
		Stream stream = File.Open(Filename, FileMode.Open);
		
		BinaryFormatter bformatter = new BinaryFormatter();
		
		charData = (ElementEmblemSong)bformatter.Deserialize(stream);
		
		Beatmaps.Add(charData);
		
		stream.Close();
		
	}
}
