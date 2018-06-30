using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RigidbodiesList", menuName = "ScriptableObjects/RigidbodiesList", order = 1)]
public class RigidbodiesList : ScriptableObject
{
    public List<Rigidbody> List = new List<Rigidbody>();
}