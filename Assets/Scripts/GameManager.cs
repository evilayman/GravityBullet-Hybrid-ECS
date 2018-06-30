using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject attractorPrefab;
    public GameObject attractablesPrefab;
    public float numberOfObjects;
    public float SpwanSize = 10f;

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            var pos = new Vector3(Random.Range(-SpwanSize / 2, SpwanSize / 2), Random.Range(0, SpwanSize), Random.Range(-SpwanSize / 2, SpwanSize / 2));
            Instantiate(attractablesPrefab, pos, Quaternion.identity);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(attractorPrefab, Camera.main.transform.position + (Camera.main.transform.forward * 1), Camera.main.transform.rotation);
        }
    }
}
