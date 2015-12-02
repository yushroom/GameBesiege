using UnityEngine;
using System.Collections;

public class destructible : MonoBehaviour {

	public SceneExplorer explorer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		//Debug.Log (col.impulse);
		if (col.impulse.magnitude > 1000) {
			explorer.explorer();
		}
	}
}
