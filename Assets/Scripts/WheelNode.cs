using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WheelController))]
public class WheelNode : Node {
	public bool clockWise = true;

	public override void initialize() {
		Debug.Log ("WheelNode.initialize()");
		base.initialize ();
		if (transform.position.x < 0)
			clockWise = false;
		Debug.Log ("here");
		WheelController controller = GetComponent<WheelController> ();
		controller.rotationDirection = clockWise ? RotationDirection.clockwise : RotationDirection.anti_clockwise;
	}
}
