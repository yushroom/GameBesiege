using UnityEngine;
using System.Collections;

public class DrawAxis : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + new Vector3(10, 0, 0));
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 10, 0));
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 0, 10));
	}

}
