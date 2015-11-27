using UnityEngine;
using System.Collections;

public class RootNode : Node {

	// Use this for initialization
	void Start () {
        bound.center = Vector3.zero;
        bound.size = Vector3.one;
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toBottom()
    {
        const float offset = 0.1f;
        Vector3 pos = this.transform.position;
        pos.y -= pos.y + bound.center.y - bound.extents.y - offset;
        this.transform.position = pos;
        bound.center.Set(bound.center.x, bound.extents.y + offset, bound.center.z);
    }
}
