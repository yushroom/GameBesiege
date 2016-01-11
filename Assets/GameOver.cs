using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public NodeManager nodeManager;
	// hide or show when game over
	public GameObject[] componentsToHide;
	public GameObject[] componentsToShow;

	// Use this for initialization
	void Start () {
		foreach (var go in componentsToShow) {
			go.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gameOver() {
		nodeManager.pauseGame ();
		nodeManager.setBuildMode (false);
		foreach (var go in componentsToShow) {
			go.SetActive(true);
		}
		foreach (var go in componentsToHide) {
			go.SetActive(false);
		}
	}
}
