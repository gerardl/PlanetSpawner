using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetSpawner
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class PhysicalBody : MonoBehaviour
    {
        public Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            GameManager.instance.AddBody(this);
        }

        void OnDisable()
        {
            GameManager.instance.RemoveBody(this);
        }

        void FixedUpdate()
        {
            foreach (var physicalBody in GameManager.instance.bodies)
            {
                if (physicalBody == this) continue;
                Attract(physicalBody);
            }
        }

        void Attract(PhysicalBody objToAttract)
        {
            // calculate force
            // f = G m1m2 / r2
            //where:
            //  F is the force between the masses;
            //  G is the gravitational constant (6.674×10−11 N · (m / kg)2);
            //  m1 is the first mass;
            //  m2 is the second mass;
            //  r is the distance between the centers of the masses.

            // use the rigibodies as the m1 and m2
            var m1 = rb;
            var m2 = objToAttract.rb;
            var G = GameManager.gravitationalConstant;
            
            // get the direction between the two objects
            Vector3 direction = (m1.position - m2.position);
            // distance between the two. (the length of direction vector)
            float r = direction.magnitude;

            // on-top of each other. collision
            if (r == 0f) return;
            
            //f = G m1m2 / r2
            var F = G * (m1.mass * m2.mass) / Mathf.Pow(r, 2);

            Vector3 force = direction.normalized * F;
            m2.AddForce(force);
        }
    }
}