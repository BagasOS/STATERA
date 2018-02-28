using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	private static GameOverManager _instance = null;
	
	public static GameOverManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType(typeof(GameOverManager)) as GameOverManager;
				
				if(_instance == null)
					_instance = new GameObject("GameOverManager").AddComponent<GameOverManager>();
			}
			return _instance;
		}
	}

	public GameObject WinPanel;
	public GameObject LosePanel;

	void Awake()
	{
		if (_instance == null) {
			_instance = this;
		}
	}

	public void Win()
	{
		PauseGame ();
		WinPanel.SetActive (true);
	}

	public void Lose()
	{
		PauseGame ();
		LosePanel.SetActive (true);
	}

	void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void Kembali()
	{
		Application.LoadLevel ("Level Select");
	}

	public void Retry()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
