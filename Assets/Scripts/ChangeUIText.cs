using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeUIText : MonoBehaviour {
	public Text text1;
	public Text text2;
	//int _index = -1;


	// Use this for initialization
	void Start () {
		hideAll ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setTextIndex(int idx) {
		if (idx == 0) {
			text1.gameObject.SetActive(true);
			text2.gameObject.SetActive(false);
		}
		else if (idx == 1) {
			text2.gameObject.SetActive(true);
			text1.gameObject.SetActive(false);
		}
	}

	public void hideAll() {
		text1.gameObject.SetActive (false);
		text2.gameObject.SetActive (false);
	}
}
