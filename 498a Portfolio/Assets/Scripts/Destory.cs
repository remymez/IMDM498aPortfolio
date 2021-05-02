using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    [SerializeField]
    GameObject objectToDestroy;

    public MiniGame gameScript;

    private RaycastHit hit;
    public LayerMask mask;

    private void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, Mathf.Infinity))
                    {
                        if (hit.transform.gameObject.CompareTag("FishHook"))
                        {
                            DestroyGameObject();
                        }
                    }
                }
            }
        }
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("FishHook"))
                {
                    DestroyGameObject();
                }
            }
        }
#endif
    }

    /*
    private void OnMouseDown()
    {
        Debug.Log("clicked");
    }*/

    public void DestroyGameObject()
    {
        gameScript.start_minigame();
        Destroy(objectToDestroy);
    }
}
