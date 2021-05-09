using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private bool mainmenu = true;
    private bool inHorde = false;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("MainMenu");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "HordeMode" && !inHorde)
        {
            mainmenu = false;
            inHorde = true;
            Stop("MainMenu");
            Play("InGameMusic");
        }
        else if(SceneManager.GetActiveScene().name == "MainMenu" && !mainmenu)
        {
            mainmenu = true;
            inHorde = false;
            Stop("InGameMusic");
            Play("MainMenu");
        }
        else if(!(SceneManager.GetActiveScene().name == "MainMenu") && !(SceneManager.GetActiveScene().name == "HordeMode"))
        {
            mainmenu = false;
            inHorde = false;
            Stop("MainMenu");
        }

    }
    // Update is called once per frame

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " was not found");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
