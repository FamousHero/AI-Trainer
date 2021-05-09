﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _OnPlayerDeath_Panel;
    [SerializeField]
    private GameObject _Rety_Button;
    [SerializeField]
    private GameObject _Rety_from_checkpoint_Button;
    [SerializeField]
	private GameObject _gameover_text;
	private bool temp = true;
    private bool mfaded = false;
    public float duration = 20f;
    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
    }


    [SerializeField]
	private float textFlickerSpeed = 0.4f;

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Quit()
	{
		print("Closing Scene");
		Application.Quit();
	}
	public void LoadLevel(string name)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(name);
	}
	public void GameOver()
	{
		Time.timeScale = 0f;
		Cursor.lockState = CursorLockMode.None;
        if (SceneManager.GetActiveScene().name == "HordeMode")
        {
            GameObject KillCount = GameObject.Find("KillCount");
            KillCount.SetActive(false);
        }
        _OnPlayerDeath_Panel.SetActive(true);
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().livesLeft() == -1)
        {
            _Rety_from_checkpoint_Button.SetActive(false);
        }
		StartCoroutine(GameOverCoroutine());
		//SceneManager.LoadScene("Credits");
		//set game over panel on
		//should have a button that quits
		//should have button that takes to main menu
	}

    IEnumerator GameOverCoroutine()
	{
		while(true)
		{
			print("e");
			_gameover_text.gameObject.SetActive(true);
			yield return new WaitForSeconds(0.5f);
			_gameover_text.gameObject.SetActive(false);
			yield return new WaitForSeconds(0.5f);
		}
	}
	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}



    public void RetryCheckPoint()
    {
        if(_OnPlayerDeath_Panel.activeSelf)
        {
            _OnPlayerDeath_Panel.SetActive(false);
        }
        if(checkpointManager != null)
			checkpointManager.DeadZone();
        Time.timeScale = 1f;
        
    }
	public void NextLevel()
	{

	}



}
