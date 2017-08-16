using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetSpawner
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        //6.67408 × 10-11 m3 kg-1 s-2
        public const float gravitationalConstant = 6.674f;

        public List<PhysicalBody> bodies = new List<PhysicalBody>();

        void Awake()
        {
            if (instance != null) Debug.Log("Already a gamemanager");
            instance = this;
        }

        public void AddBody(PhysicalBody body)
        {
            bodies.Add(body);
        }

        public void RemoveBody(PhysicalBody body)
        {
            bodies.Remove(body);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

