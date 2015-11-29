using UnityEngine;
using System.Collections;

public class ToAnotherScene : MonoBehaviour {

	public int sceneIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToSelectLevelScene() {
		Application.LoadLevel (sceneIndex);
	}
}
