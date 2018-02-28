using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelDesigner : MonoBehaviour {

	[System.Serializable]
	public class LevelDesign {
		public Sprite BG;
		public Sprite PathBG;
		public Sprite HealthBG;
	}

	public SpriteRenderer BG;
	public SpriteRenderer PathBG;
	public Image HealthBG;
	public Image StoryBG;
	public Text StoryText;

	public LevelDesign AirDesign;
	public LevelDesign ApiDesign;
	public LevelDesign KayuDesign;
	public LevelDesign LogamDesign;
	public LevelDesign TanahDesign;

	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager> ();
		UpdateLevelDesign(levelManager.Levels[levelManager.CurrentLevel].LevelDesign);
		StoryBG.sprite = levelManager.Levels [levelManager.CurrentLevel].StoryBG;
		StoryText.text = levelManager.Levels [levelManager.CurrentLevel].StoryText;
	}

	void UpdateLevelDesign(LevelManager.Design Design)
	{
		switch(levelManager.Levels[levelManager.CurrentLevel].LevelDesign)
		{
		case LevelManager.Design.Air:
			BG.sprite = AirDesign.BG;
			PathBG.sprite = AirDesign.PathBG;
			HealthBG.sprite = AirDesign.HealthBG;
			break;
		case LevelManager.Design.Api:
			BG.sprite = ApiDesign.BG;
			PathBG.sprite = ApiDesign.PathBG;
			HealthBG.sprite = ApiDesign.HealthBG;
			break;
		case LevelManager.Design.Kayu:
			BG.sprite = KayuDesign.BG;
			PathBG.sprite = KayuDesign.PathBG;
			HealthBG.sprite = KayuDesign.HealthBG;
			break;
		case LevelManager.Design.Logam:
			BG.sprite = LogamDesign.BG;
			PathBG.sprite = LogamDesign.PathBG;
			HealthBG.sprite = LogamDesign.HealthBG;
			break;
		case LevelManager.Design.Tanah:
			BG.sprite = TanahDesign.BG;
			PathBG.sprite = TanahDesign.PathBG;
			HealthBG.sprite = TanahDesign.HealthBG;
			break;
		}
	}
}
