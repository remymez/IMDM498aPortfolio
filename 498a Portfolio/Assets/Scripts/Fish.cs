using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFish
{
    string SpeciesName
    {
        get;
    }

    string Info
    {
        get;
    }

    Sprite Pic
    {
        get;
    }
}
