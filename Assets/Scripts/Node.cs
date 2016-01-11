using UnityEngine;
using System.Collections;

[System.Serializable]
public struct BoundingBox
{
    public Vector3 pmin;
    public Vector3 pmax;
}

public class Node : MonoBehaviour
{

    //public Node[] neaby_node = new Node[6];
	//[HideInInspector]
//    float _offset = -1.0f;
//	public float offset {
//		get {
//			if (_offset < 0) {
//				Vector3 p = anchorSlot.transform.position;
//				_offset = Mathf.Max(p.x, Mathf.Max(p.y, p.z));
//			}
//			return _offset;
//		}
//	}
	public float offset;
    public Bounds bound;
	bool _hasboundInWorldSpace = false;
	Bounds _boundInWorldSpace;
	public Bounds boundInWorldSpace {
		get {
			//if (!_hasboundInWorldSpace) {
				this.getTransformedBoundInLocalSpace();
			//	_hasboundInWorldSpace = true;
			//}
			return _boundInWorldSpace;
		}
		set {
			_boundInWorldSpace = value;
		}
	}
    public BoundingBox boundingBox;
    public Slot[] slots;
    public Slot anchorSlot;

	Rigidbody _rigidbody = null;
	public new Rigidbody rigidbody {
		get {
			if (_rigidbody == null)
				_rigidbody = GetComponent<Rigidbody>();
			return _rigidbody;
		}
	}

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

	public virtual void initialize() {

	}

    void OnDrawGizmos()
    {
		// draw node center
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.transform.position, 0.25f);

		// draw bounding box
		Gizmos.color = Color.yellow;
		if (_hasboundInWorldSpace)
			Gizmos.DrawWireCube (this.transform.position + boundInWorldSpace.center - this.transform.localPosition, boundInWorldSpace.size);
		else
			Gizmos.DrawWireCube (this.transform.position + bound.center, bound.size);
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

	// bound2 is in bound1's coord space
    static Bounds combine(Bounds bound1, Bounds bound2) {
        Bounds ret = new Bounds();
        Vector3 min = bound1.min;
        Vector3 max = bound1.max;
		//Debug.Log ("bound2 " + bound2);
		//Debug.Log ("min " + bound2.min);
		//Debug.Log ("max " + bound2.max);
        min.x = Mathf.Min(min.x, bound2.min.x);
        min.y = Mathf.Min(min.y, bound2.min.y);
        min.z = Mathf.Min(min.z, bound2.min.z);
        max.x = Mathf.Max(max.x, bound2.max.x);
        max.y = Mathf.Max(max.y, bound2.max.y);
        max.z = Mathf.Max(max.z, bound2.max.z);
        ret.center = (min + max) / 2;
        ret.size = max - min;
        return ret;
    }

    static void combine(ref Bounds bound, Vector3 point)
    {
        //Debug.Log(bound);
        //Debug.Log(point);
        //Debug.Log(bound.min);
        //Debug.Log(bound.max);
        Vector3 min = bound.min;
        Vector3 max = bound.max;
        min.x = Mathf.Min(min.x, point.x);
        min.y = Mathf.Min(min.y, point.y);
        min.z = Mathf.Min(min.z, point.z);
        max.x = Mathf.Max(max.x, point.x);
        max.y = Mathf.Max(max.y, point.y);
        max.z = Mathf.Max(max.z, point.z);
        bound.center = (min + max) / 2;
        bound.size = max - min;
        //Debug.Log(bound);
    }

    public void combineBound(Node other_node)
    {
        //Debug.Log(other_node.bound);
		Bounds bound_r = other_node.boundInWorldSpace;

        bound = combine(bound, bound_r);
    }

	void getTransformedBoundInLocalSpace() {
		//Debug.Log(other_node.bound);
		//Bounds bound_r = new Bounds();  // rotated bound of other_node
		_boundInWorldSpace.center = Vector3.zero;
		_boundInWorldSpace.size = Vector3.zero;
		var tr = transform.localRotation;
		//Debug.Log(tr.eulerAngles);
		Vector3 min = bound.min;
		Vector3 max = bound.max;
		//Debug.Log("min " + min);
		//Debug.Log("max " + max);
		//bound_r.center = other_node.transform.localPosition;
		//Debug.Log ("bound_r.center " + bound_r.center);
		combine(ref _boundInWorldSpace, tr * min);
		combine(ref _boundInWorldSpace, tr * new Vector3(max.x, min.y, min.z));
		combine(ref _boundInWorldSpace, tr * new Vector3(min.x, max.y, min.z));
		combine(ref _boundInWorldSpace, tr * new Vector3(min.x, min.y, max.z));
		combine(ref _boundInWorldSpace, tr * new Vector3(max.x, max.y, min.z));
		combine(ref _boundInWorldSpace, tr * new Vector3(max.x, min.y, max.z));
		combine(ref _boundInWorldSpace, tr * new Vector3(min.x, max.y, max.z));
		combine(ref _boundInWorldSpace, tr * max);
		
		// -> coord space of this node
		_boundInWorldSpace.center = transform.localPosition;
		//Debug.Log(bound_r);
	}

	public void clearSlots() {
		foreach (var slot in slots) {
		}
	}
}
