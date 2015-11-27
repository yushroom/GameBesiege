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
    public float offset;
    public Bounds bound;
    public BoundingBox boundingBox;
    public Slot[] slots;
    public Slot anchorSlot;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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

    public void updateBound()
    {
        Vector3 min = bound.min;
        Vector3 max = bound.max;
    }

    static Bounds combine(Bounds bound1, Bounds bound2) {
        Bounds ret = new Bounds();
        Vector3 min = bound1.min;
        Vector3 max = bound1.max;
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
        Debug.Log(point);
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
        Debug.Log(other_node.bound);
        Bounds bound_r = new Bounds();  // rotated bound of other_node
        var tr = other_node.transform.rotation;
        //Debug.Log(tr.eulerAngles);
        Vector3 min = other_node.bound.min;
        Vector3 max = other_node.bound.max;
        Debug.Log("min " + min);
        Debug.Log("max " + max);
        bound_r.center = other_node.transform.localPosition;
        combine(ref bound_r, tr * min);
        combine(ref bound_r, tr * new Vector3(max.x, min.y, min.z));
        combine(ref bound_r, tr * new Vector3(min.x, max.y, min.z));
        combine(ref bound_r, tr * new Vector3(min.x, min.y, max.z));
        combine(ref bound_r, tr * new Vector3(max.x, max.y, min.z));
        combine(ref bound_r, tr * new Vector3(max.x, min.y, max.z));
        combine(ref bound_r, tr * new Vector3(min.x, max.y, max.z));
        combine(ref bound_r, tr * max);

        Debug.Log(bound_r);

        bound = combine(bound, bound_r);
    }
}
