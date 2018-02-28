using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private static ScoreManager _instance = null;
	
	public static ScoreManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
				
				if(_instance == null)
					_instance = new GameObject("ScoreManager").AddComponent<ScoreManager>();
			}
			return _instance;
		}
	}

	private int score = 0;
	[SerializeField]
	private Text ScoreText;
	[SerializeField]
	private Text AccuracyText;
	[SerializeField]
	private Text RankText;
	public int multiplier = 1;
	public SongLoad SongLoad;
	[SerializeField]
	public float accuracy = 0;
	private int notesCount;
	private int notesHit = 0;

	void Awake()
	{
		if (_instance == null) {
			_instance = this;
		}
	}
	
	void Start () {
		ResetScore ();
	}

	void Update () {
	
	}

	public void AddScore(int point)
	{
		notesHit++;
		UpdateAccuracy ();
		score += point * multiplier;
		ScoreText.text = score.ToString ();
	}

	public void ChangeMultiplier(int i)
	{
		multiplier = i;
	}

	void ResetScore()
	{
		score = 0;
		ScoreText.text = score.ToString ();
	}

	void UpdateAccuracy()
	{
		accuracy = (float)notesHit / (float)notesCount * 100;
		AccuracyText.text = accuracy.ToString ("F2");

		if (accuracy >= 90.0f)
			RankText.text = "Rank A";
		else if (accuracy >= 85.0f && accuracy < 90.0f)
			RankText.text = "Rank B";
		else if (accuracy >= 65.0f && accuracy < 85.0f)
			RankText.text = "Rank C";
		else if (accuracy >= 45.0f && accuracy < 65.0f)
			RankText.text = "Rank D";
		else if (accuracy < 45.0f)
			RankText.text = "Rank E";
	}

	public void AssignNotesCount(int count)
	{
		notesCount = count;
	}
	public void Kembali(){
		Application.LoadLevel ("Level Select");
	}
}
