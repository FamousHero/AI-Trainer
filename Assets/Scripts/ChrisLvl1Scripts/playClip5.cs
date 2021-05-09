using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playClip5 : MonoBehaviour
{
    public GodHand gh;

    [SerializeField]
    private GameObject _endLevel;

	private void Start()
	{
        _endLevel.gameObject.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            print("Play");
            

            gh.playClip(5);
            StartCoroutine(LoadLevelCoroutine());


        }
    }
    IEnumerator LoadLevelCoroutine()
	{
        yield return new WaitForSeconds(6.3f);
        //Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        _endLevel.gameObject.SetActive(true);
    }
}
