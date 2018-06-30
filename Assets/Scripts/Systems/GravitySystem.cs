using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GravitySystem : ComponentSystem
{
    struct AttractableFilter
    {
        public Attractable data;
        public Rigidbody rb;
    }

    protected override void OnUpdate()
    {
        ComponentGroupArray<AttractableFilter> myAttractables = GetEntities<AttractableFilter>();

        float deltaTime = Time.deltaTime;

        foreach (var eAttractable in myAttractables)
        {
            for (int i = 0; i < eAttractable.data.attractorsList.List.Count; i++)
            {
                ApplyGravity(eAttractable.data.attractorsList.List[i], eAttractable.rb, deltaTime);
            }
        }
    }

    private void ApplyGravity(Rigidbody attractor, Rigidbody attractable, float deltaTime)
    {
        Vector3 dir = attractor.position - attractable.position;
        float distance = dir.magnitude;

        if (distance == 0)
            return;

        float forceMangnitude = 1000 * (attractor.mass * attractable.mass) / Mathf.Pow(distance, 2);
        Vector3 force = dir.normalized * forceMangnitude;
        attractable.AddForce(force * deltaTime);
    }
}
