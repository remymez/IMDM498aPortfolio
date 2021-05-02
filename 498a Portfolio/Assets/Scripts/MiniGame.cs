using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject trash;
    public GameObject gift;
    public GameObject spiral_shell;
    public GameObject s_fan_shell;
    public GameObject sand_dollar;
    public GameObject b_fan_shell;

    public GameObject trash_item1;
    public GameObject trash_item2;
    public GameObject trash_item3;
    public GameObject trash_item4;
    private ArrayList items = new ArrayList();

    private int collected;
    public float xPos;
    public float yPos;
    public float zPos;

    public void start_minigame()
    {
        
        StartCoroutine(spawn_items());

    }
    private GameObject temp;
    private int item_type;


    IEnumerator spawn_items()
    {
        while (collected < 31)
        {
            xPos = Random.Range((float)-4, (float)2.5);
            yPos = Random.Range((float) -6, (float) 6);
            zPos = Random.Range((float)10, (float)12);
            item_type = Random.Range(1, 8);
            temp = Instantiate((GameObject) items[item_type], new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Destroy(temp);
            collected += 1;
            yield return new WaitForSeconds(5f);
        }
    }
    void Start()
    {
        items.Add(spiral_shell);
        items.Add(s_fan_shell);
        items.Add(sand_dollar);
        items.Add(b_fan_shell);
        items.Add(trash_item1);
        items.Add(trash_item2);
        items.Add(trash_item3);
        items.Add(trash_item4);
        collected = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
