using UnityEngine;
using System.Collections;

public class PositionReset : MonoBehaviour {
    Vector3 originalPosition;
    Quaternion originalRotation;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void reset()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}