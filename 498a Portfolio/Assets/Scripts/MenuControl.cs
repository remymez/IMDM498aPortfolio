using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadARFishTank()
    {
        SceneManager.LoadScene("ARFishTank");
    }

    public void LoadFishFinder()
    {
        SceneManager.LoadScene("GPS");
    }

    public void LoadCommunityFishTank()
    {

    }
}
