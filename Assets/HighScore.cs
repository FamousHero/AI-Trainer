using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text highScore;
    GameObject player;
    bool newhs = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerStatTrack>().getKillCount() > PlayerPrefs.GetFloat("HighScore", 0f) || newhs)
        {
            newhs = true;
            highScore.text = "New High Score!\n" + player.GetComponent<PlayerStatTrack>().getKillCount();
            PlayerPrefs.SetFloat("HighScore", player.GetComponent<PlayerStatTrack>().getKillCount());
            
        }
        else
        {
            highScore.text = "High Score\n" + PlayerPrefs.GetFloat("HighScore", 0f);
        }
    }
}
