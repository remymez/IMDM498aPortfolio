using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayDialogue : MonoBehaviour
{
    private AudioSource source;
    private AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        clip = source.clip;
    }

    public void PlaySound()
    {
        source.Stop();
        source.PlayOneShot(clip);
    }
}
