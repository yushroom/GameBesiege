using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

    public enum SlotDirection
    {
        postive_x,
        negtive_x,
        postive_y,
        negtive_y,
        postive_z,
        negtive_z
    }

    public SlotDirection direction;
    public Node node;
    public Node otherNode;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (node != null && otherNode != null) {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(node.transform.position, otherNode.transform.position);
        }
        Gizmos.DrawCube(this.transform.position, Vector3.one * 0.1f);
    }
}
