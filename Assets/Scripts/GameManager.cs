﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager _UIManager;

    public void LoadNextLevel(string levelName, float delay)
    {
        StartCoroutine(LoadLevelCoroutine(levelName, delay));
    }
    IEnumerator LoadLevelCoroutine(string l, float d)
    {
        yield return new WaitForSeconds(d);
        SceneManager.LoadScene(l);

    }
    public void OnPlayerDeath()
	{
        //freezes time
        //Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
            
        _UIManager.GameOver();

        //set some UI up to say "GAME OVER"
        //freeze time
        //UI should have some way to get back to main menu
        //record how many times player died STATS
	}
    // Start is called before the first frame update
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_UIManager == null) Debug.LogError("Canvas not found");
    }

    
}
