using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TankManagerScript : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI info;
    public Image image;

    public ARRaycastManager arRaycastManager;
    public LayerMask mask;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
            {
                if (hit.transform.gameObject.CompareTag("Fish"))
                {
                    IFish fish = hit.transform.gameObject.GetComponent<IFish>();
                    if (fish != null)
                    {
                        title.text = fish.SpeciesName;
                        info.text = fish.Info;
                        image.sprite = fish.Pic;
                    }
                }
            }
        }*/

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, Mathf.Infinity, mask))
                    {
                        if (hit.transform.gameObject.CompareTag("Fish"))
                        {
                            IFish fish = hit.transform.gameObject.GetComponent<IFish>();
                            if (fish != null)
                            {
                                title.text = fish.SpeciesName;
                                info.text = fish.Info;
                                image.sprite = fish.Pic;
                            }
                        }
                    }
                }
            }
        }
    }
}
