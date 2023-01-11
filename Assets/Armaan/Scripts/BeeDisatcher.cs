using System;
using System.Collections.Generic;
using UnityEngine;

    public class BeeDisatcher : MonoBehaviour
    {

        [SerializeField] List<GameObject> beesInSwarm = new();
        public bool dispatch = false;
        DeathState death;
        private void Start()
        {
            DeathState death = GetComponent<DeathState>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dispatch = true;
            }
            if (beesInSwarm == null)
            {
                death.enabled = true;
            }
        }

    }
