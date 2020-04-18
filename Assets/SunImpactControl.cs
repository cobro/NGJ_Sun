using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SunImpactControl : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]

    private VisualEffect visualEffect;

    [SerializeField, Range(0, 2)]
    private float Impact = 0;

    // Update is called once per frame
    void Update()
    {

        visualEffect.SetFloat("Impact", Impact);
    }
}
