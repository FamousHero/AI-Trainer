﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for shooting the physical prototype building
//Basically moved shoot function from the Player script into here
//And then mashed it with code from the shootingHitscan script
public class ShootingPhysical : MonoBehaviour
{
    //[SerializeField]
    private GameObject player;
    [SerializeField]
    private int type = 1; //What type of fire maode is used. 1 = semi auto, 2 = full auto
    [SerializeField]
    private float semifireRate = .25f; // How quickly the gun can fire as a semi-automatic
    [SerializeField]
    private float autofireRate = .25f; // How quickly the gun can fire as a fully automatic
    [SerializeField]
    private GameObject _bulletPrefab;// What bulet we will be shooting
    [SerializeField]
    private Transform gunEnd;// The end of the gun
    [SerializeField]
    private AudioSource Asource;//Audio source for the gun when it shoots

    private float nextFireTime;//This used with fireRate determines when the gun can fire

	// Start is called before the first frame update
	private void Start()
	{
        player = GameObject.Find("Player");
	}
	void Update()
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), player.GetComponent<PlayerKeyBindings>().getshootGun())) && Time.time > nextFireTime && type == 1 && !GetComponent<GunController>().isReloading)
        {
            setCoolDown();
            Shoot();
        }
        else if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), player.GetComponent<PlayerKeyBindings>().getshootGun())) && Time.time > nextFireTime && type == 2 && !GetComponent<GunController>().isReloading)
        {
            setCoolDown();
            Shoot();
        }
    }

    void Shoot()
    {
        //player.GetComponent<AccuracyCounter>().ShotsFired();
        GameObject bullet = Instantiate(_bulletPrefab, gunEnd.position, gunEnd.rotation);
        Asource.Play();
        gameObject.GetComponent<GunController>().decreaseAmmo();
    }

    void setCoolDown()
    {
        if (type == 1)
        {
            nextFireTime = Time.time + semifireRate;
        }
        else
        {
            nextFireTime = Time.time + autofireRate;
        }
    }
}
