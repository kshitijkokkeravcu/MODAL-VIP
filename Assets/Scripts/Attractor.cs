using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    bool isElectron = false;

    public const float k = 15f;
    public float maxSpeed = 1f; // Maximum speed limit for charges

    public Rigidbody rb;

    public static List<Attractor> Attractors;

    private void FixedUpdate()
    {
        // Apply attraction forces
        foreach (Attractor attractor in Attractors)
        {
            if (this != attractor)
            {
                Attract(attractor);
            }
        }

        // Clamp the velocity of the charge to the maximum speed
        LimitSpeed();
    }

    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Attractor>();
        }

        Attractors.Add(this);
    }

    private void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;

        float distance = direction.magnitude;

        if (distance == 0f)
        {
            return;
        }

        float forceMagnitude = k * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        if (this.isElectron == objToAttract.isElectron)
        {
            rbToAttract.AddForce(-force);
        }
        else
        {
            rbToAttract.AddForce(force);
        }
    }

    void LimitSpeed()
    {
        // Clamp the velocity to the max speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
