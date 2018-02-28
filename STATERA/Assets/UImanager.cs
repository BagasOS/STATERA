using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {

	public Animator standbySetting;
	public Animator StandbyPlay;
	public Animator standbyInfo;
	public Animator buttonSetting;
	public Animator buttonInfo;
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void SettingNotHidden(){

		StandbyPlay.SetBool ("isTouch", true);
		StandbyPlay.SetBool ("isHidden", true);
		standbySetting.SetBool ("isTouch", true);
		standbySetting.SetBool ("isHidden", false);
		buttonSetting.SetBool ("isTouchButton", true);
		buttonSetting.SetBool ("isHidden", true);
		buttonInfo.SetBool ("isTouchButton", true);
		buttonInfo.SetBool ("isHidden", true);
	}

	public void SettingHidden(){
		StandbyPlay.SetBool ("isHidden", false);
		standbySetting.SetBool ("isHidden", true);
		buttonInfo.SetBool ("isHidden", false);
		buttonSetting.SetBool ("isHidden", false);
	}

	public void infoNotHidden(){
		StandbyPlay.SetBool ("isTouch", true);
		StandbyPlay.SetBool ("isHidden", true);
		standbyInfo.SetBool ("isTouchinfo", true);
		standbyInfo.SetBool ("isHidden", false);
		buttonSetting.SetBool ("isTouchButton", true);
		buttonSetting.SetBool ("isHidden", true);
		buttonInfo.SetBool ("isTouchButton", true);
		buttonInfo.SetBool ("isHidden", true);
	}

	public void infoHidden(){
		standbyInfo.SetBool ("isHidden", true);
		buttonInfo.SetBool ("isHidden", false);
		buttonSetting.SetBool ("isHidden", false);
		StandbyPlay.SetBool ("isHidden", false);
		standbySetting.SetBool ("isHidden", true);

	}
	public void Playthegame(){
		Application.LoadLevel ("Level Select");
	}
}
