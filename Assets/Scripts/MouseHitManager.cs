using UnityEngine;
using System.Collections;

public class MouseHitManager : MonoBehaviour {

	//GameObject lastHoverGameobject;
	MouseHit _lastMouseHover = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			var mouseHit = hit.transform.gameObject.GetComponent<MouseHit> ();
			if (mouseHit == null) {
				if (_lastMouseHover != null)
					_lastMouseHover.OnHoverEnd ();
				return;
			}

			if (_lastMouseHover != null && mouseHit != _lastMouseHover) {
				//Debug.Log("hover end");
				_lastMouseHover.OnHoverEnd ();
			} else {
				mouseHit.OnHoverBegin ();
			}
			if (Input.GetMouseButtonDown (0)) {
				//Debug.Log ("hit");		
				mouseHit.OnHit ();
			}
			_lastMouseHover = mouseHit;
		} else {
			if (_lastMouseHover != null)
				_lastMouseHover.OnHoverEnd ();
		}
	}
}
