using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(ConstantForce))]
public class buoyancyForce : MonoBehaviour {

	ConstantForce _force;
	public Vector3 maxForce;
	public KeyCode key;
	public UnityEvent onKeyDown;

	// Use this for initialization
	void Start () {
		_force = GetComponent<ConstantForce> ();
		reset ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (key)) {
			//Debug.Log ("holding " + key);
			_force.force = new Vector3(transform.up.x * maxForce.x, transform.up.y * maxForce.y, transform.up.z * maxForce.z);
			onKeyDown.Invoke();
		} else {
			//Debug.Log("release " + key);
			reset();
		}
	}

	// set force to zero
	void reset() {
		// ? .Set(0,0,0) has no effect, wired
		_force.force = Vector3.zero;
	}
}
