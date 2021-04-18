using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class PlaceTank : MonoBehaviour
{
    public GameObject tank;
    public ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> arRaycastHits;
    private bool spawned;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
       arRaycastHits = new List<ARRaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {
                        if (arRaycastHits[0] != null && !spawned)
                        {
                            var pose = arRaycastHits[0].pose;
                            Place(pose.position);
                            spawned = true;
                        }
                    }
                }
            }
        }
    }

    void Place(Vector3 pos)
    {
        GameObject addedTank = Instantiate(tank, pos, Quaternion.identity);
        addedTank.transform.localScale = Vector3.one * .1f;
    }
}
