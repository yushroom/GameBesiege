using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(ConstantForce))]
public class buoyancyForce : MonoBehaviour {

	ConstantForce _force;
	public float maxForce;
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
			_force.force = transform.up * maxForce;
			//Debug.Log(_force.force);
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
