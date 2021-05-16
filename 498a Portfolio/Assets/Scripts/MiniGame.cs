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

    public AudioSource speech;
    public AudioClip[] dialogue;

    public GameObject[] subtitles;

    public Animator anim;
    private bool isGameOver;
    private bool gameStarted;
    private bool restarted;
    public TextMeshProUGUI collectedText;
    public TextMeshProUGUI mistakeText;

    public void start_minigame()
    {
        if (!restarted)
        {
            StartCoroutine(hook_removed());
            gameStarted = true;
            collectedText.text = "Collected: 0";
            mistakeText.text = "Mistakes: 0";
        } else
        {
            gameStarted = true;
            StartCoroutine(spawn_items());
            collectedText.text = "Collected: 0";
            mistakeText.text = "Mistakes: 0";
        }
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
                yield return new WaitForSeconds(15f);
            }
        }

        if(isGameOver && collected < 10)
        {
            StartCoroutine(play_lose());
            restarted = true;

        }

    }

    IEnumerator play_win()
    {
        speech.clip = dialogue[12];
        subtitles[12].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[12].SetActive(false);


        speech.clip = dialogue[13];
        subtitles[13].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[13].SetActive(false);
    }

    IEnumerator play_lose()
    {
        speech.clip = dialogue[14];
        subtitles[14].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[14].SetActive(false);
    }

    IEnumerator play_dialogue_testudo()
    {
        speech.clip = dialogue[0];
        subtitles[0].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[0].SetActive(false);

        speech.clip = dialogue[1];
        subtitles[1].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[1].SetActive(false);

        speech.clip = dialogue[2];
        subtitles[2].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[2].SetActive(false);

        speech.clip = dialogue[3];
        subtitles[2].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[2].SetActive(false);


    }

    IEnumerator hook_removed()
    {
        speech.clip = dialogue[4];
        subtitles[4].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[4].SetActive(false);

        speech.clip = dialogue[5];
        subtitles[5].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[5].SetActive(false);

        speech.clip = dialogue[6];
        subtitles[6].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[6].SetActive(false);

        speech.clip = dialogue[7];
        subtitles[7].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[7].SetActive(false);

        speech.clip = dialogue[8];
        subtitles[8].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[8].SetActive(false);

        speech.clip = dialogue[9];
        subtitles[9].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[9].SetActive(false);

        speech.clip = dialogue[10];
        subtitles[10].SetActive(true);
        speech.PlayOneShot(speech.clip);
        yield return new WaitForSeconds(speech.clip.length);
        subtitles[10].SetActive(false);

        StartCoroutine(spawn_items());
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
        restarted = false;
        StartCoroutine(play_dialogue_testudo());
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
