using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Beam : MonoBehaviour
{
    public float charge_m = 1;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("have");
    }


}
