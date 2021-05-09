using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlerp : MonoBehaviour
{
    public float xSlerpVal;
    public float ySlerpVal;
    public float zSlerpVal;
    public float speed;

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, transform.position + new Vector3(xSlerpVal, ySlerpVal, zSlerpVal), speed * Time.deltaTime);
    }
}
