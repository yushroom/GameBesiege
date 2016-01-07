using UnityEngine;
using System.Collections;

public class HideUI : MonoBehaviour {
	
	RectTransform _transform;
	
	// Use this for initialization
	void Start () {
		_transform = GetComponent<RectTransform> ();
	}
	
	public void hidde() {
		gameObject.SetActive (false);
	}
	
	public void show() {
		this.enabled = true;
		gameObject.SetActive (true);
	}
}
