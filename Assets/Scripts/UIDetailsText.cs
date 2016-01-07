using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIDetailsText : MonoBehaviour {

	RectTransform rectTransform;
	public Text textUI;
	public string text {
		get {
			return textUI.text;
		}
		set {
			textUI.text = value;
		}
	}

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		rectTransform.sizeDelta = textUI.rectTransform.sizeDelta + Vector2.one*20;
	}

	public void display(bool enabled = true) {
		//float height = textUI.preferredWidth;
		//float width = textUI.preferredWidth;
		//rectTransform.sizeDelta.Set (height + 2 * 10 , width + 2 * 10);
		if (enabled)
			rectTransform.sizeDelta = textUI.rectTransform.sizeDelta + Vector2.one*20;
		gameObject.SetActive (enabled);
	}

	public void setPosition(Vector3 newPosition) {
		rectTransform.position = newPosition;
	}
}
