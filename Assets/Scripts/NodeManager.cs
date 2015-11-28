using UnityEngine;
using System.Collections;

public class NodeManager : MonoBehaviour {

    public bool build_mode = true;
    public Node root;
	public Bounds bigCubeBounds;
    public Node[] one_nodes;
    public Node[] prefabs;
    public Node[] nodes;
    int component_index = 0;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}

	public void startGame()
    {
        Time.timeScale = 1;
		build_mode = false;
		//var nodes = GetComponentsInChildren<Node> ();
		//foreach (Node node in nodes) {
		//	Rigidbody rg = node.GetComponent<Rigidbody>();
		//	if (rg != null) {
		//		rg.useGravity = true;
		//	}
		//}
	}

    static Vector3[] _direction = { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 1, 0), 
                                  new Vector3(0, -1, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1)};

	// Update is called once per frame
	void Update () 
	{
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    if (build_mode && Physics.Raycast(ray, out hit)) 
		{
			makeNodeFromHit(hit);
        }
	}

	void makeNodeFromHit(RaycastHit hit)
	{
		GameObject go 	= hit.transform.gameObject;
		Node node 		= go.GetComponent<Node>();
		Node one_node 	= one_nodes[component_index];
		one_node.gameObject.SetActive(false);
		if (node == null || go.tag == "OneNode")
		{
			//Debug.Log("not a node");
			one_node.gameObject.SetActive(false);
			return;
		}
		
		Slot slot = node.getNearestSlot(hit.point);
		if (slot == null)
			return;
		Vector3 slotMainDirection = go.transform.rotation * _direction[(int)slot.direction];
		one_node.transform.position = slot.transform.position + slotMainDirection.normalized * one_node.offset;
		one_node.transform.rotation = 
			Quaternion.FromToRotation(one_node.anchorSlot.transform.localPosition, slot.transform.position - one_node.transform.position);
		Bounds expectedBound = one_node.boundInWorldSpace;
		//Debug.Log("min " + expectedBound.min);
		//Debug.Log("max " + expectedBound.max);
		if (!(bigCubeBounds.Contains(expectedBound.min) && bigCubeBounds.Contains(expectedBound.max))) {
			return;
		}
		one_node.gameObject.SetActive(true);
		
		if (Input.GetMouseButtonDown(0))
		{
			one_node.gameObject.SetActive(false);
			Node new_node = Instantiate(prefabs[component_index], one_node.transform.position, one_node.transform.rotation) as Node;
			new_node.initialize();
			new_node.anchorSlot.otherNode = node;
			
			// setup joint
			FixedJoint joint1 = node.gameObject.AddComponent<FixedJoint>();
			//FixedJoint joint2 = new_node.gameObject.AddComponent<FixedJoint>();
			joint1.connectedBody = new_node.rigidbody;
			//joint2.connectedBody = node.rigibody;
			
			slot.otherNode = new_node;
			one_node.gameObject.SetActive(false);
			one_node.transform.rotation = Quaternion.identity;
			new_node.transform.parent = root.transform;
			new_node.boundInWorldSpace = expectedBound;
			root.combineBound(new_node);
		}
	}

    Vector3 mainDirection(Vector3 dir)
    {
        Vector3 position_offset = Vector3.zero;
        //Debug.Log(dir);
        Vector3 abs_dir = dir;
        if (abs_dir.x < 0) abs_dir.x = -abs_dir.x;
        if (abs_dir.y < 0) abs_dir.y = -abs_dir.y;
        if (abs_dir.z < 0) abs_dir.z = -abs_dir.z;
        int max_axis = 0;
        if (abs_dir.x > abs_dir.y)
            max_axis = abs_dir.x > abs_dir.z ? 0 : 2;
        else
            max_axis = abs_dir.y > abs_dir.z ? 1 : 2;
        if (max_axis == 0) position_offset.x = dir.x > 0 ? 1 : -1;
        else if (max_axis == 1) position_offset.y = dir.y > 0 ? 1 : -1;
        else position_offset.z = dir.z > 0 ? 1 : -1;
        return position_offset;
    }

    public void changeComponentIndex(int index)
    {
        if (index < 0) index = 0;
        if (index > 2) index = 2;
        this.component_index = index;
    }

	public void makeACar()
	{
	}

    public void destoryAllNodes()
    {
        // child 0 is center cube
        for (int i = transform.childCount - 1; i > 0; --i)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
