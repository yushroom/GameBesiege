using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    //public Node[] neaby_node = new Node[6];
    public float offset;
    public Slot[] slots;

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

    public virtual Slot getNearestSlot(Vector3 point) {
        
        Slot retSlot = slots[0];
        float minDist = Vector3.Distance(point, retSlot.transform.position);
        for (int i = 1; i < slots.Length; ++i )
        {
            var slot = slots[i];
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
