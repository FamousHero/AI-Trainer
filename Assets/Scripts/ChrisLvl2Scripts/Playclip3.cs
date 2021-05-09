using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playclip3 : MonoBehaviour
{
    public godhandv2 gh;
    public GameObject gateDoor2;
    public GameObject sniperFloor;
    public GameObject laserAmmo;
    public float w8Time;
    private bool audioPlaying = false;
    private bool wallsLowered = false;
    private float timer;

    private void Start()
    {
        timer = w8Time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (gameObject.GetComponent<Spawner>().spawnCounter == 0 && !audioPlaying)
            {
                audioPlaying = true;
                gh.playClip(2);
                Destroy(sniperFloor);
                laserAmmo.SetActive(true);
            }
            else if (gh.triggerChecker == 3 && !wallsLowered)
            {
                //Destroy(gateDoor1);
                Animator gd2 = gateDoor2.GetComponent<Animator>();
                gd2.SetTrigger("GateOpen2");
                wallsLowered = true;
                gameObject.GetComponent<Playclip3>().enabled = false;
            }
        }
        else {
            timer -= Time.deltaTime;
        }
    }
}
