﻿using UnityEngine;
using System.Collections;

public class NodeManager : MonoBehaviour {

    public bool build_mode = true;
    public Node[] one_nodes;
    public Node[] prefabs;
    public Node[] nodes;
    int component_index = 0;

	// Use this for initialization
	void Start () {
	
	}

    static Vector3[] _direction = { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 1, 0), 
                                  new Vector3(0, -1, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1)};

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    if (build_mode && Physics.Raycast(ray, out hit)) {
            GameObject go = hit.transform.gameObject;
            Node node = go.GetComponent<Node>();
            var one_node = one_nodes[component_index];
            if (node == null || go.tag == "OneNode")
            {
                //Debug.Log("not a node");
                one_node.gameObject.SetActive(false);
                return;
            }

            Slot slot = node.getNearestSlot(hit.point);
            Vector3 slotMainDirection = go.transform.rotation * _direction[(int)slot.direction];
            one_node.transform.position = slot.transform.position + slotMainDirection.normalized * one_node.offset;
            one_node.transform.rotation = Quaternion.FromToRotation(one_node.anchorSlot.transform.localPosition,
                                                                    slot.transform.position - one_node.transform.position);
            one_node.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                one_node.gameObject.SetActive(false);
                Node new_node = Instantiate(prefabs[component_index]) as Node;
                new_node.transform.position = one_node.transform.position;
                //new_node.transform.rotation = Quaternion.FromToRotation(new_node.anchorSlot.transform.position - new_node.transform.position, 
                //                                                        slot.transform.position - new_node.transform.position);
                new_node.transform.rotation = one_node.transform.rotation;
                //int oppositeDirection = (int)slot.direction + ((int)slot.direction % 2 + 1) % 2;
                //new_node.slots[oppositeDirection].otherNode = node;
                new_node.anchorSlot.otherNode = node;
                //node.slots[(int)slot.direction].otherNode = new_node;
                slot.otherNode = new_node;
                one_node.gameObject.SetActive(false);
                one_node.transform.rotation = Quaternion.identity;
            }
        }
	}

    Vector3 mainDirection(Vector3 dir) {
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

    public void changeComponentIndex(int index) {
        if (index < 0) index = 0;
        if (index > 1) index = 1;
        this.component_index = index;
    }
}