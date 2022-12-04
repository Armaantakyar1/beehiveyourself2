using System;
using System.Collections.Generic;
using UnityEngine;




    public class BeeDisatcher : MonoBehaviour
    {
        [SerializeField] List<GameObject> beesInSwarm = new();
        public bool dispatch = false;
       
        private void Update()
        {
        // check if the current flower is not null
        // if true then check if the button id pressed and only then add


            if (Input.GetKeyDown(KeyCode.Space))
            {
                dispatch = true;
            }


        }

    }
