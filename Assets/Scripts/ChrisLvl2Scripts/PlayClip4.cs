using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClip4 : MonoBehaviour
{
    public godhandv2 gh;
    public GameObject gateDoor3;
    public GameObject MachineGunFloor;
    public GameObject RacerSpawner;
    private bool audioPlaying = false;
    private bool wallLowered = false;
    // Update is called once per frame
    void Update()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        if (children.Length == 1 && !audioPlaying)
        {
            gh.playClip(3);
            audioPlaying = true;
            Destroy(MachineGunFloor);
        }
        else if (gh.triggerChecker == 4 && !wallLowered) {
            wallLowered = true;
            Animator gd3 = gateDoor3.GetComponent<Animator>();
            gd3.SetTrigger("GateOpen3");
            RacerSpawner.SetActive(true);
        }
    }
}
