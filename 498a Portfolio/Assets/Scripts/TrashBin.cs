using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public GameObject theCube;
    private MiniGame gameScript;
    private DragObject dragScript;

    private void Start()
    {
        dragScript = theCube.GetComponent<DragObject>();
        gameScript = theCube.GetComponent<MiniGame>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("BigFanShell(Clone)"))
        {
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("SandDollar(Clone)"))
        {
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("SmallFanShell(Clone)"))
        {
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("SpiralShell(Clone)"))
        {
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("BottleOfWater(Clone)"))
        {
            gameScript.collected += 1;
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("Bottle2(Clone)"))
        {
            gameScript.collected += 1;
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("Battery1(Clone)"))
        {
            gameScript.collected += 1;
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("Var2_LOD0(Clone)"))
        {
            gameScript.collected += 1;
            dragScript.dragging = false;
            dragScript.toDrag = null;
            Destroy(other.gameObject);
        }
    }
}
