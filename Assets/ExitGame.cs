using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void exitGame() {
		Debug.Log("exit");
		Application.Quit ();
	}
}
