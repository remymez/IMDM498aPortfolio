using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfographicMover : MonoBehaviour
{
    public GameObject content;

    private bool animating;
    private float interpolationParameter;

    private void Start()
    {
        animating = false;
    }

    public void moveUp()
    {
        if (content.transform.localPosition.y > 0 && !animating)
        {
            StartCoroutine(move(1));
        } else if (content.transform.localPosition.y > -1435 && content.transform.localPosition.x == 0 && !animating)
        {
            StartCoroutine(move(1));
        }
        
    }

    public void moveDown()
    {
        if (content.transform.localPosition.y < 1435 && !animating)
        {
            StartCoroutine(move(0));
        }
    }

    public void moveRight()
    {
        if (content.transform.localPosition.x > -800 && content.transform.localPosition.y > -1435 && !animating)
        {
            StartCoroutine(move(2));
        }
    }

    public void moveLeft()
    {
        if (content.transform.localPosition.x < 800 && content.transform.localPosition.y > -1435 && !animating)
        {
            StartCoroutine(move(3));
        }
    }

    IEnumerator move(int dir)
    {
        if (animating)
        {
            yield return null;
        }

        animating = true;
        Vector3 newPos = Vector3.zero;

        switch (dir)
        {
            case 0:
                newPos = content.transform.localPosition + new Vector3(0f, 1435f, 0f);
                break;
            case 1:
                newPos = content.transform.localPosition + new Vector3(0f, -1435f, 0f);
                break;
            case 2:
                newPos = content.transform.localPosition + new Vector3(-800f, 0f, 0f);
                break;
            case 3:
                newPos = content.transform.localPosition + new Vector3(800f, 0f, 0f);
                break;
            default:
                break;
        }

        Vector3 originallocalPosition = content.transform.localPosition;
        interpolationParameter = 0f;
        while (interpolationParameter < 1f)
        {
            interpolationParameter += Time.deltaTime / 1.5f;
            content.transform.localPosition = Vector3.Lerp(originallocalPosition, newPos, interpolationParameter);
            yield return null;
        }
        animating = false;
    }
}
