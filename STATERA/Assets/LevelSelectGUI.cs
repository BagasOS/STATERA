using UnityEngine;
using System.Collections;

public class LevelSelectGUI : MonoBehaviour {

	public Animator[] allAnim;
	private LevelManager levelManager;
	
	void Start () {
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();
	}

	void Update () {
	
	}

	public void OpenSlide(GameObject Slide)
	{
		foreach(Animator a in allAnim)
		{
			a.SetBool("SlideDown", false);
		}

		Animator anim;
		anim = Slide.GetComponent<Animator> ();
		if (anim.GetBool ("SlideDown") == false)
			anim.SetBool ("SlideDown", true);
		else
			anim.SetBool ("SlideDown", false);
	}

	public void LoadLevel(int level)
	{
		levelManager.CurrentLevel = level;
		Application.LoadLevel ("Master Level");
	}
}
