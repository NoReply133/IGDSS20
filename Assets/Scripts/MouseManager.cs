using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private bool rightClickOn = false;
    private int maxPos = 160;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = new Vector3(maxPos, 80, 80);
    }

    // Update is called once per frame
    void Update()
    {
        handLeftClick();
        handleZoom();
        handleXZMovement();
    }

    void handLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    void handleZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 1)
            {
                Camera.main.fieldOfView--;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView < 100)
            {
                Camera.main.fieldOfView++;
            }
        }
    }

    void handleXZMovement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            rightClickOn = true;
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            rightClickOn = false;
        }

        if (rightClickOn)
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                if (Camera.main.transform.position.z > 0)
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z-1);
                }
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                if (Camera.main.transform.position.z < maxPos)
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z+1);
                }
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                if (Camera.main.transform.position.y > 0)
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y-1, Camera.main.transform.position.z);
                }
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                if (Camera.main.transform.position.y < maxPos)
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y+1, Camera.main.transform.position.z);
                }
            }
        }
    }
}
