using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private AI ai;
    private Material material;
    private float dissolve_num = 0f;
    private float isDissolved = 1f;
    public bool startDissolve = false;
    // Start is called before the first frame update
    private void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        if (startDissolve)
        {
            dissolve_num = Mathf.Lerp(dissolve_num, isDissolved, 2f * Time.deltaTime);
            material.SetFloat("_dissolve_num", dissolve_num);
        }
        if (dissolve_num >= isDissolved - .3f)
            ai.Die();
    }
}
