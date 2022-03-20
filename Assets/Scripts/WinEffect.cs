using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffect : MonoBehaviour
{
    public AudioClip winSound;
    public AudioSource musicSource;
    public GameObject winText;
    private bool winState;

    // Start is called before the first frame update
    void Start()
    {
        winState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (winText.activeSelf)
        {
            PlayWin();
        }
    }

    void PlayWin()
    {
       if (winState == false)
        {
            winState = true;
            musicSource.clip = winSound;
            musicSource.Play();
        }
    }
}
