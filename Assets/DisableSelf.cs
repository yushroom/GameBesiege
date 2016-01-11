using UnityEngine;
using System.Collections;

public class DisableSelf : MonoBehaviour {

	public float time = 2.0f;
	public GameObject target;

	// Use this for initialization
	void Start () {
		StartCoroutine(waitAndCall(time));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator waitAndCall(float waitTime) {
		//Debug.Log ("llllllll");
		yield return new WaitForSeconds(waitTime);
		target.SetActive (false);
	}
}
