using UnityEngine;
using System.Collections;

public class SceneExplorer : MonoBehaviour {
	public GameObject oldGameObject;
	public GameObject parts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void explorer() {
		oldGameObject.SetActive (false);
		parts.SetActive (true);
	}
}
