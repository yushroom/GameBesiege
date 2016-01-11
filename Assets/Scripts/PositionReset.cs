using UnityEngine;
using System.Collections;

public class PositionReset : MonoBehaviour {
    Vector3 originalPosition;
    Quaternion originalRotation;
	Rigidbody _rigidbody;
	WheelController _wheelController;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
		_rigidbody = GetComponent<Rigidbody> ();
		_wheelController = GetComponent<WheelController> ();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void reset()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
		if (_rigidbody != null) {
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularDrag = 0;
			_rigidbody.angularVelocity = Vector3.zero;
		}
		if (_wheelController != null) {
		}

    }
}