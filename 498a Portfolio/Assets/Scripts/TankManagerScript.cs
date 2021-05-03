using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TankManagerScript : MonoBehaviour
{
    public Canvas infoPage;
    public Canvas backBtnCanvas;

    public ARRaycastManager arRaycastManager;
    public LayerMask mask;

    private bool active;
    private RaycastHit hit;

    public Sprite[] screens;
    private GameObject content;
    private Image contentImage;
    private int currPage;

    private void Awake()
    {
        active = false;
        infoPage.gameObject.SetActive(false);
        backBtnCanvas.gameObject.SetActive(true);
        content = infoPage.transform.Find("Content").gameObject;
        contentImage = content.GetComponent<Image>();
        currPage = 0;
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
                        active = true;
                        infoPage.gameObject.SetActive(true);
                        backBtnCanvas.gameObject.SetActive(false);
                        currPage = 0;
                        contentImage.sprite = screens[currPage];
                    }
                }
            }
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
                                active = true;
                                infoPage.gameObject.SetActive(true);
                                backBtnCanvas.gameObject.SetActive(false);
                                currPage = 0;
                                contentImage.sprite = screens[currPage];
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
        active = false;
        infoPage.gameObject.SetActive(false);
        backBtnCanvas.gameObject.SetActive(true);
    }

    public void nextPage()
    {
        if (currPage < screens.Length - 1)
        {
            currPage++;
            contentImage.sprite = screens[currPage];
        }
    }

    public void prevPage()
    {
        if (currPage > 0)
        {
            currPage--;
            contentImage.sprite = screens[currPage];
        }
    }
}
