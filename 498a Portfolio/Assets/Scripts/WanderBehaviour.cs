using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WanderBehaviour : MonoBehaviour
{
    private float walkSpeed = .1f;
    public LayerMask mask;
    private Vector3 wayPoint;
    private float Range = 4;
    private bool isRotating;
    private Quaternion targetRotation;
    private float interpolationParameter;

    public Animator anim;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        Range *= .15f;
        anim.SetBool("swimming", true);
        isRotating = false;
        Wander();
    }

    void Update()
    {
        //Debug.Log("is Rotating: " + isRotating);
        if (!isRotating)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), .15f, mask) ||
                Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * -1), .03f, mask) ||
                Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), .03f, mask)) {
                //Debug.Log("in update raycasts");
                Wander();
            }
            else
            {
                transform.position += transform.TransformDirection(Vector3.forward) * walkSpeed * Time.deltaTime;
                if ((wayPoint - transform.position).magnitude < .15)
                {
                    //Debug.Log("Magnitude");
                    Wander();
                }
            } 
        }
    }

    void Wander()
    {
        wayPoint = new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), Random.Range(transform.position.y - .0525f, transform.position.y + .0525f), Random.Range(transform.position.z - Range, transform.position.z + Range));
        targetRotation = Quaternion.LookRotation(wayPoint - transform.position);
        /*
        if (Physics.Raycast(transform.position, transform.TransformDirection(wayPoint - transform.position), 1f, ~mask))
        {
            Wander();
        }*/
        StartCoroutine(DoRotation(targetRotation));
        /*
        else
        {
            StartCoroutine(DoRotation(targetRotation));
        }*/
    }

    IEnumerator DoRotation(Quaternion dir)
    {
        if (isRotating)
        {
            yield return null;
        }

        anim.SetBool("swimming", false);
        isRotating = true;
        Quaternion originalRotation = transform.rotation;

        interpolationParameter = 0f;
        while (interpolationParameter < 1f)
        {
            interpolationParameter += Time.deltaTime / 1.5f;
            transform.rotation = Quaternion.Lerp(originalRotation, dir, interpolationParameter);
            yield return null;
        }
        anim.SetBool("swimming", true);
        isRotating = false;
    }
}
