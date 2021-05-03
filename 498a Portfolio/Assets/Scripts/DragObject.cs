using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float dist;
    public bool dragging = false;
    private Vector3 offset;
    public Transform toDrag;

    void Update()
    {
# if UNITY_ANDROID
        Vector3 v3;

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
            {
                Debug.Log("Here");
                toDrag = hit.transform;
                dist = hit.transform.position.z - Camera.main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                offset = toDrag.position - v3;
                dragging = true;
            }
        }
        if (dragging && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
        }
# endif

# if UNITY_EDITOR
        Vector3 vec;

        Vector3 posit = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(posit);
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
            {
                toDrag = hit.transform;
                dist = hit.transform.position.z - Camera.main.transform.position.z;
                vec = new Vector3(posit.x, posit.y, dist);
                vec = Camera.main.ScreenToWorldPoint(vec);
                offset = toDrag.position - vec;
                dragging = true;
            }
        }
        if (dragging)
        {
            vec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            vec = Camera.main.ScreenToWorldPoint(vec);
            toDrag.position = vec + offset;
        }
        if (dragging && Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
# endif
    }
}
