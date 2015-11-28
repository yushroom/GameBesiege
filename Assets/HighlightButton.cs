using UnityEngine;
using System.Collections;

public class HighlightButton : MonoBehaviour {

    public float scale = 1.5f;
    public RectTransform background;
    RectTransform rectTransfrom;
    Vector2 rect;

	// Use this for initialization
	void Start () {
        rectTransfrom = GetComponent<RectTransform>();
        rect = rectTransfrom.sizeDelta;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void select()
    {
        background.position = rectTransfrom.position;
    }

    public void enableHighlight()
    {
        rectTransfrom.sizeDelta = rect * scale;
    }

    public void disableHighlight()
    {
        rectTransfrom.sizeDelta = rect;
    }
}
