using UnityEngine;
using System.Collections;

public class showConfigureVehicleSubsteps : MonoBehaviour {
	
	public float speedThreshold = 5;
	public int stepsBelowThreshold = 12;
	public int stepsAboveThreshold = 12;
	
	// Use this for initialization
	void Start () {
		GetComponent<WheelCollider> ().ConfigureVehicleSubsteps (speedThreshold, stepsBelowThreshold, stepsAboveThreshold);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
