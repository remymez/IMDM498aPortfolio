using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : MonoBehaviour
{
    public float walkSpeed = .5f;
    private Vector3 wayPoint;
    private float Range = 4;
    private RaycastHit hit;
    private bool inCoroutine;
    private bool isRotating;
    private Quaternion targetRotation;
    private float interpolationParameter;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("swimming", true);
        inCoroutine = false;
        isRotating = false;
        Wander();
    }

    void Update()
    {
        if (!isRotating)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * -1), 1f) ||
                Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), .2f) ||
                Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * -1), .2f)) {
                Wander();
            }
            else
            {
                transform.position += transform.TransformDirection(Vector3.right * -1) * walkSpeed * Time.deltaTime;
                if ((wayPoint - transform.position).magnitude < .5)
                {
                    Wander();
                }
            } 
        }
    }

    void Wander()
    {
        wayPoint = new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), Random.Range(transform.position.y - .35f, transform.position.y + .35f), Random.Range(transform.position.z - Range, transform.position.z + Range));
        targetRotation = Quaternion.LookRotation(wayPoint - transform.position);
        if (Physics.Raycast(transform.position, transform.TransformDirection(wayPoint - transform.position), 1f))
        {
            Wander();
        } 
        else
        {
            StartCoroutine(DoRotation(targetRotation));
        }
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
