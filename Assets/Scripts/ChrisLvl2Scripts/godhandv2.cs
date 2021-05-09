using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godhandv2 : MonoBehaviour
{
    public AudioClip[] voiceLines;
    public AudioSource aSource;
    public int triggerChecker;

    // Start is called before the first frame update
    void Start()
    {
        triggerChecker = 0;
    }

    IEnumerator playClip()
    {
        aSource.Play();
        yield return new WaitWhile(() => aSource.isPlaying);
        triggerChecker++;
    }

    public void playClip(int clipNum)
    {
        aSource.clip = voiceLines[clipNum];
        StartCoroutine(playClip());
    }
}
