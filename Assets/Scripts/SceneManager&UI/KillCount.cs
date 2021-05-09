using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCount : MonoBehaviour
{
    private PlayerStatTrack playerStatTrack;
    [SerializeField]
    private Text killCount;
    // Start is called before the first frame update
    void Start()
    {
        playerStatTrack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatTrack>();
    }

    // Update is called once per frame
    void Update()
    {
        killCount.text = "Kill Count \n" + playerStatTrack.getKillCount().ToString();
    }
}
