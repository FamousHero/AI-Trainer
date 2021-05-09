using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateCameraCoroutine());
    }

    IEnumerator RotateCameraCoroutine()
	{
        
        while(true)
		{
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
            yield return new WaitForSeconds(0.2f);
		}
	}
}
