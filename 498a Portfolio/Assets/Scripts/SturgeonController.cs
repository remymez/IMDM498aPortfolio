using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SturgeonController : MonoBehaviour, IFish
{
    public Sprite pic;

    public string Info => "Test Info Sturgeon";

    public string SpeciesName => "Test Name Sturgeon";

    public Sprite Pic => pic;

}
