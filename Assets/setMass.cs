using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMass : MonoBehaviour
{

    Rigidbody rb;
    float massCoefficient = 100;
    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = transform.localScale.x * massCoefficient;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
