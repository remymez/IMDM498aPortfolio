using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void LoadARFishTank()
    {
        SceneManager.LoadScene("ARFishTank");
    }

    public void LoadFishFinder()
    {
        //SceneManager.LoadScene("OtherSceneName");
    }

    public void LoadCommunityFishTank()
    {

    }
}
