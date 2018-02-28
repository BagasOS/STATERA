using UnityEngine;
using System.Collections;

public class backgroundscript : MonoBehaviour {

	private int bgIndex = 0;
	public Sprite[] backgrounds;
	private SpriteRenderer render;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		StartCoroutine (ganti (bgIndex));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ganti(int index)
	{
		render.sprite = backgrounds [index];
		yield return new WaitForSeconds (2.0f);
		bgIndex++;
		if (bgIndex >= backgrounds.Length)
			bgIndex = 0;
		StartCoroutine(ganti(bgIndex));
	}
}
