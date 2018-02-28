using UnityEngine;
using System.Collections;

public class SkillCutIn : MonoBehaviour {

	private static SkillCutIn _instance = null;

	public static SkillCutIn instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType(typeof(SkillCutIn)) as SkillCutIn;

				if(_instance == null)
					_instance = new GameObject("SkillCutIn").AddComponent<SkillCutIn>();
			}
			return _instance;
		}
	}

	public GameObject SkillCutInImage;
	public float SkillTime = 10.0f;
	public GameObject[] SkillFX;
	public ScoreManager scoreManager;
	private bool SkillUsed = false;

	void Awake()
	{
		if (_instance == null) {
			_instance = this;
		}
	}

	void Update()
	{
		if (!SkillUsed && scoreManager.accuracy > 50) {
			SkillCutIn.instance.Skill (3.0f);
			SkillUsed = true;
		}
			
	}

	public void Skill(float seconds)
	{
		StartCoroutine (SkillCut (seconds));
	}

	IEnumerator SkillCut(float seconds)
	{
		Time.timeScale = 0;
		Camera.main.GetComponent<AudioSource> ().Pause ();
		SkillCutInImage.SetActive (true);

		yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(seconds));
		Time.timeScale = 1.0f;
		Camera.main.GetComponent<AudioSource> ().Play ();
		SkillCutInImage.SetActive (false);
		StartCoroutine (StartSkill (SkillTime));
	}

	IEnumerator StartSkill(float time)
	{
		ScoreManager.instance.ChangeMultiplier (2);
		foreach (GameObject sfx in SkillFX) {
			sfx.SetActive(true);
		}
		yield return new WaitForSeconds(time);
		ScoreManager.instance.ChangeMultiplier (1);
		foreach (GameObject sfx in SkillFX) {
			sfx.SetActive(false);
		}
	}
}
