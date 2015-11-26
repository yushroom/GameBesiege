using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    //public Node[] neaby_node = new Node[6];
    public float offset;
    public Slot[] slots;
    public Slot anchorSlot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.transform.position, 0.25f);
    }

    public virtual Slot getNearestSlot(Vector3 point) 
	{
		Slot retSlot = null;
		float minDist = float.MaxValue;
		foreach (var slot in slots) 
		{
			if (slot.otherNode != null)
				continue;
            float dist = Vector3.Distance(point, slot.transform.position);
            if (minDist >= dist)
            {
                minDist = dist;
                retSlot = slot;
            }
        }
        return retSlot;
    }
}
