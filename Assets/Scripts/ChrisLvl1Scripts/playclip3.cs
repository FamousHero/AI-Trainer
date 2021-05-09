﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playclip3 : MonoBehaviour
{
    public Checkpoint[] checkpoints;
    public GodHand gh;
    public bool allCheckpointsTouched = false;
    public GameObject wall;
    public GameObject wind;
    public GameObject windpart;
    private bool playedclip = false;
    // Update is called once per frame
    void Update()
    {
        foreach (Checkpoint ch in checkpoints) {
            if (!ch.getTriggerState()) {
                allCheckpointsTouched = false;
                break;
            }
            allCheckpointsTouched = true;
        }
        if (allCheckpointsTouched && !playedclip) {
            gh.playClip(3);
            playedclip = true;
        }
        if (gh.triggerChecker == 4) {
            wall.GetComponent<WallSlerp>().enabled = true;
            wind.SetActive(true);
            windpart.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
