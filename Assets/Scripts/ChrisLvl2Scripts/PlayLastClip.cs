using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLastClip : MonoBehaviour
{
    public godhandv2 gh;
    
    private NextLevelUI nxlvui;
    private bool audioPlaying = false;
    public float w8Time;
    private float timer;
    private void Start()
    {
        timer = w8Time;
        nxlvui = GameObject.Find("levlLADER").GetComponent<NextLevelUI>();

        if (nxlvui == null) Debug.LogError("yo f this sht");
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (gameObject.GetComponent<Spawner>().spawnsLeft() == 0 && gameObject.GetComponent<Spawner>().spawnCounter == 0 && !audioPlaying)
            {
                audioPlaying = true;
                gh.playClip(4);
                nxlvui.LoadNextLevel("HordeMode", 5f);
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
