﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Hayat
{

    class BeeDisatcher : MonoBehaviour
    {
        public List<BeeDisatcher> beesInSwarm = new();
        bool dispatch;

        private void Update()
        {
            // check if the current flower is not null
            // if true then check if the button id pressed and only then add
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dispatch = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            /// did I Collide with a flower
           /// if Yes 
           /// check if the flower can hold more bees         
           /// set current flower to be th
           /// add bee to flower
           if (other.CompareTag("Flowers"))
            {
                if (dispatch == true)
                {
                    FlowerBehaviour currentflower = other.GetComponent<FlowerBehaviour>();
                    if (currentflower.bees.Count == 0)
                    {
                        currentflower.bees.Clear();
                    }
                    

                }
            }


        }

        protected void AddBeToFlower(FlowerBehaviour selected)
        {
            /// 
            /// /// if yes give it one of the bees and remove it from swarm the list
            /// // tell the bee you removed to follow the flower instead of follwing the swarm
            /// 
        }
    }
}