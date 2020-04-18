using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class setMass : MonoBehaviour
{

    Rigidbody rb;
    Rigidbody rbToAttract;
    Rigidbody orbitedBody;
    float orbitedBodyDistance = 100000;
    float massCoefficient = 100;
    float G = 6.67f;
    float randomScale;
    float angle;
    public bool Sun = false;
    public bool Planet = false;
    public bool Moon = false;
    public float orbitalSpeed;
    Vector3 shit = new Vector3(1,1,1);
    
    public static List<setMass> Attractors;
    public static List<Rigidbody> Suns;
    public static List<Rigidbody> Planets;
    public static List<Rigidbody> Moons;



    void Start()
    {
        angle = Random.Range(0, 360);
        if (Planet == true && Suns!=null)
        {
            foreach(Rigidbody tempRB in Suns){
                float tempOrbitedBodyDistance = Vector3.Distance(tempRB.position, transform.position);
                if (tempOrbitedBodyDistance < orbitedBodyDistance)
                {
                    orbitedBodyDistance = tempOrbitedBodyDistance;
                    orbitedBody = tempRB;
                }
            }
            orbitalSpeed = Mathf.Sqrt(G*orbitedBody.mass/orbitedBodyDistance);
            rb.AddForce(Quaternion.AngleAxis(angle, rb.position) * Vector3.Cross(shit, rb.position).normalized * orbitalSpeed, ForceMode.VelocityChange);
            Debug.DrawLine(rb.position, rb.position + Quaternion.AngleAxis(angle, rb.position) * Vector3.Cross(shit, rb.position).normalized * 20, Color.red, 10);
        }
    }

    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<setMass>();
        }
        Attractors.Add(this);

        if (Sun == true)
        {
            if (Suns == null)
            {
                Suns = new List<Rigidbody>();
            }
            Suns.Add(this.rb);
        }
        if (Planet == true)
        {
            if (Planets == null)
            {
                Planets = new List<Rigidbody>();
            }
            Planets.Add(this.rb);
        }
        if (Moon == true)
        {
            if (Moons == null)
            {
                Moons = new List<Rigidbody>();
            }
            Moons.Add(this.rb);
        }
    }

    private void OnDisable()
    {
        Attractors.Remove(this);
        if (Suns != null && Sun)
            Suns.Remove(this.rb);
        if (Planets != null && Planet)
            Planets.Remove(this.rb);
        if (Moons != null && Moon)
            Moons.Remove(this.rb);
    }

   /* private void Update()
    {
        if(orbitedBody != null)
        {
            Debug.DrawLine(rb.position, orbitedBody.position);
            Debug.DrawLine(rb.position, rb.position + Quaternion.AngleAxis(Random.Range(0, 360), rb.position - orbitedBody.position) * Vector3.Cross(shit, rb.position - orbitedBody.position).normalized * 20);
        }
        
    }*/

    private void OnValidate()
    {
        //randomScale = Random.Range(1, 10);
        //transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        rb = GetComponent<Rigidbody>();
        rb.mass = transform.localScale.x * massCoefficient;
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
