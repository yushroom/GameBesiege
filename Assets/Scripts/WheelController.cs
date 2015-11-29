using UnityEngine;
using System.Collections;

public enum RotationDirection {
	clockwise,
	anti_clockwise
}

[RequireComponent(typeof(Rigidbody))]
public class WheelController : MonoBehaviour {
	public WheelCollider wheelCollider;
	public float maxMotorTorque = 400;
	public float maxSteeringAngle = 30;
	public bool isMotorWheel = true;
	public Transform wheelMesh;
	public RotationDirection rotationDirection = RotationDirection.clockwise;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	// finds the corresponding visual wheel
	// correctly applies the transform
	public void ApplyLocalPositionToVisuals(WheelCollider collider)
	{
		if (collider.transform.childCount == 0) {
			//return;
		}
		
		//Transform visualWheel = collider.transform.GetChild(0);
		Transform visualWheel = wheelMesh;

		Vector3 position;
		Quaternion rotation;
		collider.GetWorldPose(out position, out rotation);
		
		visualWheel.transform.position = position;
		visualWheel.transform.rotation = rotation;
	}

	public void ApplyLocalPositionToVisuals() {
	}
	
	public void FixedUpdate()
	{
		float motor = - maxMotorTorque * Input.GetAxis("Vertical");
        //Debug.Log(motor);
		if (isMotorWheel) {
			wheelCollider.motorTorque = (rotationDirection == RotationDirection.clockwise) ? motor : motor * -1;
			//wheelCollider.motorTorque = motor;
		}
		ApplyLocalPositionToVisuals(wheelCollider);
	}
}
