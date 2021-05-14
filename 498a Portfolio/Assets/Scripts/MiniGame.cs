using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    private Quaternion rotator = Quaternion.Euler(new Vector3(90f, 0f, 0f));

    private GPSHandler gps;

    public bool testMode;
    public int collected;
    public int mistakes;
    public float xPos;
    public float yPos;
    public float zPos;

    private AudioSource audio;

    public Animator anim;
    private bool isGameOver;
    private bool gameStarted;

    public TextMeshProUGUI collectedText;
    public TextMeshProUGUI mistakeText;

    public void start_minigame()
    {
        gameStarted = true;
        StartCoroutine(spawn_items());
        collectedText.text = "Collected: 0";
        mistakeText.text = "Mistakes: 0";
    }
    private GameObject temp;
    private int item_type;


    IEnumerator spawn_items()
    {
        yield return new WaitForSeconds(5f);
        if (!testMode)
        {
            while (collected < 10 && !isGameOver)
            {
                xPos = Random.Range((float)-4, (float)2.5);
                yPos = Random.Range((float)-1.5, (float)6);
                zPos = 12.5f; //Random.Range((float)10, (float)12);
                item_type = gps.UpdateLocation();
                temp = Instantiate((GameObject)items[item_type], new Vector3(xPos + transform.position.x, yPos + transform.position.y, zPos), Quaternion.identity * rotator);
                temp.transform.SetParent(gameObject.transform);
                yield return new WaitForSeconds(3.5f);
            }
        }
        else
        {
            while (collected < 10 && !isGameOver)
            {
                xPos = Random.Range((float)-4, (float)2.5);
                yPos = Random.Range((float)-1.5, (float)6);
                zPos = 12.5f; //Random.Range((float)10, (float)12);
                item_type = Random.Range(0,8);
                temp = Instantiate((GameObject)items[item_type], new Vector3(xPos + transform.position.x, yPos + transform.position.y, zPos), Quaternion.identity * rotator);
                temp.transform.SetParent(gameObject.transform);
                yield return new WaitForSeconds(3.5f);
            }
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
        mistakes = 0;
        isGameOver = false;
        collectedText.text = "";
        mistakeText.text = "";
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mistakes >= 5)
        {
            anim.SetBool("isDead", true);
            isGameOver = true;
        }

        if (gameStarted)
        {
            collectedText.text = "Collected: " + collected.ToString();
            mistakeText.text = "Mistakes: " + mistakes.ToString();
        }
    }
}
