using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playClip2 : MonoBehaviour
{
    public godhandv2 gh;
    public GameObject BulletSpawner;
    public GameObject SpiderSpawner;
    public GameObject pistolFloor;
    //public GameObject wall1;
    //public GameObject wall2;
    public GameObject gateDoor1;
    private bool wallslowered = false;

    private bool _trigger = false;

    private void Update()
    {
        if (gh.triggerChecker == 2 && !wallslowered) {
            Animator gd1 = gateDoor1.GetComponent<Animator>();
            gd1.SetTrigger("GateOpen1");
            SpiderSpawner.SetActive(true);
            wallslowered = true;
            gameObject.GetComponent<playClip2>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_trigger == false)
        {
            if (other.tag == "Player")
            {
                gh.playClip(1);
                BulletSpawner.SetActive(true);
                Destroy(pistolFloor);
                _trigger = true;
            }
        }
    }
}
