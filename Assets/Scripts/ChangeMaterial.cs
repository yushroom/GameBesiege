using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ChangeMaterial : MonoBehaviour {

	MeshRenderer _render;
	public Material material;
	Material _oldMaterial;

	// Use this for initialization
	void Start () {
		_render = GetComponent<MeshRenderer> ();
		_oldMaterial = _render.material;
	}

	public void change() {
		_render.material = material;
	}

	public void changeBack() {
		_render.material = _oldMaterial;
	}
}
