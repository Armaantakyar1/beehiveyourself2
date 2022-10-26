using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Hayat
{
    /// <summary>
    /// thid class will keep track of all the bees follwing the swarm and dispatch them to flowers when needed
    /// </summary>
    class BeeDisatcher : MonoBehaviour
    {
        List<Bee> beesInSwarm;
        FlowerBehaviour currentFlower;

        private void Update()
        {
            // check if the current flower is not null
            // if true then check if the button id pressed and only then add
        }

        private void OnTriggerEnter(Collider other)
        {
            /// did I Collide with a flower
           /// if Yes 
           /// check if the flower can hold more bees
           /// 
           /// set current flower to be th
           /// add bee to flower

        }

        protected void AddBeToFlower(FlowerBehaviour selected)
        {
            /// 
            /// /// if yes give it one of the bees and remove it from swarm the list
            /// // tell the bee you removed to follow the flower instead of follwing the swarm
            /// 
        }
        private void OnTriggerExit(Collider other)
        {
            
        }
    }
}