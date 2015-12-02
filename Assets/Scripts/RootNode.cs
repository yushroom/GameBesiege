using UnityEngine;
using System.Collections;

public class RootNode : Node {

	// Use this for initialization
	void Start () {
        bound.center = Vector3.zero;
        bound.size = Vector3.one;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		// draw node center
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(this.transform.position, 0.25f);
		
		// draw bounding box
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube (bound.center + transform.position, bound.size);
	}

    public void toBottom()
    {
        const float offset = 0.2f;
        Vector3 pos = this.transform.position;
        pos.y -= pos.y + bound.center.y - bound.extents.y - offset;
        this.transform.position = pos;
        bound.center.Set(bound.center.x, bound.extents.y + offset, bound.center.z);
    }
}
