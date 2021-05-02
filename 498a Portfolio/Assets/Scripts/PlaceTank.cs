using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class PlaceTank : MonoBehaviour
{
    public GameObject tank;
    public GameObject sturg;
    public ARRaycastManager arRaycastManager;
    public ARPlaneManager arPlaneManager;
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
# if UNITY_ANDROID
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
                            spawned = true;
                            Place(pose.position);
                        }
                    }
                }
            }
        }
# endif

#if UNITY_EDITOR
        if (Input.GetMouseButton(0) && !spawned)
        {
            spawned = true;
            Place(new Vector3(0f, 0f, 0f));
        }
#endif
    }

    void Place(Vector3 pos)
    {
        Quaternion placementRot = Quaternion.identity * Quaternion.Euler(0f, -180f, 0f);
        GameObject addedTank = Instantiate(tank, pos, placementRot);
        addedTank.transform.localScale = Vector3.one * .15f;
        foreach (var plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        arPlaneManager.enabled = false;
        GameObject newSturg = Instantiate(sturg, addedTank.transform.position + new Vector3(0f, .9f, 0f), Quaternion.identity);
        newSturg.transform.localScale = Vector3.one * .15f;
    }
}
