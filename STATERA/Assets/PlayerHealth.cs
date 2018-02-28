using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private static PlayerHealth _instance = null;
	
	public static PlayerHealth instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
				
				if(_instance == null)
					_instance = new GameObject("PlayerHealth").AddComponent<PlayerHealth>();
			}
			return _instance;
		}
	}

	public float max_health = 100f;
	public float cur_health = 0f;
	public GameObject HPbar;

	void Awake()
	{
		if (_instance == null) {
			_instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		cur_health = max_health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decreasedhealth(float damage){
		cur_health -= damage;
		if (cur_health <= 0)
			GameOverManager.instance.Lose ();
		float calc_health = cur_health / max_health; // if cur 80 / 100 - 0.8f
		sethpbar (calc_health);
	}

	public void increasedhealth(float point){
		cur_health += point;
		if (cur_health > max_health)
			cur_health = max_health;
		float calc_health = cur_health / max_health; // if cur 80 / 100 - 0.8f
		sethpbar (calc_health);
	}

	void sethpbar(float myhealth){
		//myhealth value 0-1
		HPbar.transform.localScale = new Vector3(1.0f, myhealth ,1.0f );
	}
}
