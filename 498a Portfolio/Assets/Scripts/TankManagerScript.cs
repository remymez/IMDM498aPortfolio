using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TankManagerScript : MonoBehaviour
{
    public Canvas[] infoDiagrams;
    private Canvas currPage;
    /*
    public Text title;
    public Text info;
    public Image image;
    */

    public ARRaycastManager arRaycastManager;
    public LayerMask mask;

    private bool active;
    private RaycastHit hit;

    private void Awake()
    {
        active = false;
        currPage = null;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (!active && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
            {
                if (hit.transform.gameObject.CompareTag("Fish"))
                {
                    IFish fish = hit.transform.gameObject.GetComponent<IFish>();
                    if (fish != null)
                    {
                        /*
                        title.text = fish.SpeciesName;
                        info.text = fish.Info;
                        image.sprite = fish.Pic;
                        */
                        currPage = getDiagramByName(fish.infoName);
                        if (currPage != null)
                        {
                            active = true;
                            currPage.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            hideInfoPage();
        }
# endif

# if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (!active && Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, Mathf.Infinity, mask))
                    {
                        if (hit.transform.gameObject.CompareTag("Fish"))
                        {
                            IFish fish = hit.transform.gameObject.GetComponent<IFish>();
                            if (fish != null)
                            {
                                /*
                                title.text = fish.SpeciesName;
                                info.text = fish.Info;
                                image.sprite = fish.Pic;
                                */
                                currPage = getDiagramByName(fish.infoName);
                                if (currPage != null)
                                {
                                    active = true;
                                    currPage.gameObject.SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
# endif
    }

    public void hideInfoPage()
    {
        if (currPage != null)
        {
            active = false;
            currPage.gameObject.SetActive(false);
            currPage = null;
        }
    }

    private Canvas getDiagramByName(string infoDiagram)
    {
        foreach (Canvas canvas in infoDiagrams)
        {
            if (canvas.name.Equals(infoDiagram))
            {
                return canvas;
            }
        }

        return null;
    }
}
