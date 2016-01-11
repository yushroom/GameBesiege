using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	//public Vector3 axis = new Vector3(0, 1, 0);
	public float speed = 1.0f;
	bool _rotating;
    public bool auto = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (auto) {
            rotate();
		}
	}

	void OnDrawGizmos() {
		//Gizmos.DrawLine (transform.position, transform.position + transform.parent.up);
	}

	public void rotate() {
		//Debug.Log(name + " is rotating.");
		//transform.Rotate(transform.parent.up, speed);
		var ea = transform.localEulerAngles;
		ea.y += speed;
		transform.localEulerAngles = ea;
	}
}
