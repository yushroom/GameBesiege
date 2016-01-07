using UnityEngine;
using System.Collections;

public class UIDisplayDetailText : MonoBehaviour {

	public string text;
	public UIDetailsText detailsText;
	public Vector2 positionOffset;
	RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void display() {
		detailsText.text = text;
		Vector2 pos = rectTransform.position;
		pos.x += positionOffset.x;
		pos.y += positionOffset.y;
		detailsText.setPosition (pos);
		detailsText.display (true);
	}

	public void hide() {
		detailsText.display (false);
	}
}
