using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SunImpactControl : MonoBehaviour
{
    [SerializeField]
    private VisualEffect visualEffect;
    public float MaxImpact = 0;
    private float Impact = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Impact = MaxImpact;
        visualEffect.SetFloat("Impact", Impact);
    }

    private void OnCollisionExit(Collision collision)
    {
        Impact = 0;
        visualEffect.SetFloat("Impact", Impact);
        Debug.Log("Collision ended");
    }
}
