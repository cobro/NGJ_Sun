using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class setMass : MonoBehaviour
{

    Rigidbody rb;
    Rigidbody rbToAttract;
    float massCoefficient = 10;
    float G = 6.67f;
    float randomScale;
    public static List<setMass> Attractors;


    void Start()
    {
    }

    private void OnValidate()
    {
        randomScale = Random.Range(1, 10);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        rb = GetComponent<Rigidbody>();
        rb.mass = transform.localScale.x * massCoefficient;
    }

    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<setMass>();
        }
        Attractors.Add(this);
    }

    private void OnDisable()
    {
        Attractors.Remove(this);
    }

    private void FixedUpdate()
    {
        attract();
    }

    void attract()
    {
        for (int i = 0; i < Attractors.Count; i++)
        {
            if(Attractors[i] != this)
            {
                rbToAttract = Attractors[i].rb;
                Vector3 direction = rbToAttract.position - rb.position;
                float forceMagnitude = (G * rb.mass * rbToAttract.mass) / direction.sqrMagnitude;
                Vector3 force = direction.normalized * forceMagnitude;
                rb.AddForce(force);
            }
        }
    }
}
