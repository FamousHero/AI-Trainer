using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NextLevelUI : MonoBehaviour
{
	public GameObject _nextLevelPanel;

	private void Start()
	{
		_nextLevelPanel = GameObject.FindGameObjectWithTag("LevelLoader");
	}
	public void LoadNextLevel(string levelName, float delay)
	{
		StartCoroutine(LoadLevelCoroutine(levelName,delay));
	}
	
	IEnumerator LoadLevelCoroutine(string l, float d)
	{
		yield return new WaitForSeconds(d);

		if(_nextLevelPanel != null)
			_nextLevelPanel.gameObject.SetActive(true);
		else
		{
			Debug.LogError("nxt is null");
			_nextLevelPanel = GameObject.FindGameObjectWithTag("LevelLoader");
			_nextLevelPanel.gameObject.SetActive(true);
		}
		//_nextLevelPanel = GameObject.FindGameObjectWithTag("LevelLoader");
		//Time.timeScale = 0f;
		//Cursor.lockState = CursorLockMode.None;
		SceneManager.LoadScene(l);

	}
}
