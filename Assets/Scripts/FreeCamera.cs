using UnityEngine;
using System.Collections;

public class FreeCamera : MonoBehaviour {

    public Transform target;

    public float xRotateSpeed = 4.0f;
    public float yRotateSpeed = 4.0f;
    public float xDragSpeed = 1f;
    public float yDragSpeed = 1f;

    bool m_in_rotate_mode = false;
    bool m_in_drag_mode = false;

	// Use this for initialization
	void Start () {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update () {

        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftAlt))
            m_in_rotate_mode = true;
        if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.LeftAlt))
            m_in_rotate_mode = false;
        if (Input.GetMouseButtonDown(2))
            m_in_drag_mode = true;
        if (Input.GetMouseButtonUp(2))
            m_in_drag_mode = false;

        if (m_in_rotate_mode)
        {
            //Debug.Log("right mouse button");
            //y = ClampAngle(y, yMinLimit, yMaxLimit);
            float y_angle = Input.GetAxis("Mouse X") * xRotateSpeed;
            float x_angle = -Input.GetAxis("Mouse Y") * yRotateSpeed;
            transform.RotateAround(target.position, transform.up, y_angle);
            transform.RotateAround(target.position, transform.right, x_angle);
        }
        else if (m_in_drag_mode)
        {
            float x = Input.GetAxis("Mouse X") * xDragSpeed;
            float y = Input.GetAxis("Mouse Y") * yDragSpeed;
            //var offset = transform.up * x + transform.right * y;
            transform.Translate(-x, -y, 0);
        }
        else
        {
            float distance = Input.GetAxis("Mouse ScrollWheel") * 5;
            this.transform.position += distance * this.transform.forward;
        }
	}

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 260;
        if (angle > 260) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
