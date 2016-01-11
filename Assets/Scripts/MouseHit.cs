using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]
public class MouseHit : MonoBehaviour {

	public UnityEvent onHoverBegin;
	public UnityEvent onHoverEnd;
	public UnityEvent onHit;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnHoverBegin() {
		onHoverBegin.Invoke ();
	}

	public void OnHoverEnd() {
		onHoverEnd.Invoke ();
	}

	public void OnHit() {
		onHit.Invoke ();
	}
}
