using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeginningClips : MonoBehaviour
{
    public godhandv2 gh;

    private void Start()
    {
        if (gh.triggerChecker == 0)
        {
            gh.playClip(0);
        }
    }
}
