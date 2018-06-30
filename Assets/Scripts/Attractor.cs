using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public RigidbodiesList attractorsList;
    public float speed;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        attractorsList.List.Add(GetComponent<Rigidbody>());
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       rb.velocity = transform.forward * speed;
    }

    private void OnDisable()
    {
        Repulse();
        attractorsList.List.Remove(GetComponent<Rigidbody>());
    }

    private void Repulse()
    {
        var attractablesArr = FindObjectsOfType<Attractable>();

        for (int i = 0; i < attractablesArr.Length; i++)
        {
            Rigidbody attractable = attractablesArr[i].GetComponent<Rigidbody>();

            Vector3 dir = rb.position - attractable.position;
            float distance = dir.magnitude;

            if (distance == 0)
                return;

            float forceMangnitude = 1000 * (rb.mass * attractable.mass) / Mathf.Pow(distance, 2);
            Vector3 force = dir.normalized * forceMangnitude;

            attractable.AddForce(-force * Time.deltaTime, ForceMode.Impulse);
        }

    }
}
