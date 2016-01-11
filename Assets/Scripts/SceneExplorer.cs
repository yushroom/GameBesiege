using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SceneExplorer : MonoBehaviour {
	public GameObject oldGameObject;
	public GameObject parts;

	public UnityEvent onExploded;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void explorer() {
		oldGameObject.SetActive (false);
		parts.SetActive (true);
		audioSource.Play ();
		StartCoroutine(waitAndCall(3.0f));
	}

	IEnumerator waitAndCall(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		onExploded.Invoke ();
	}
}
