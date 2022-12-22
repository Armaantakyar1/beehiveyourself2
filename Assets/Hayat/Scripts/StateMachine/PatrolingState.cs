using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PatrolingState : State
{
    State inspectingState;
    public bool collided;
    public Transform[] destinationPoints;
    public int index = 0;
    [SerializeField] SeekingBehaviour seeker;
    /*public override State RunState()
    {
        


        if (Vector3.Distance(this.transform.position, destinationPoints[index].position) <= 0.5f)
        {
            GetComponent<Attacking>().chasingTimer = 0;
            index++;

            if (index == destinationPoints.Length)
            {
                index = 0;
            }
        }
        if (collided== true)
        {
            return inspectingState;
        }
    }

    void RunThese()
    {
        GetComponent<SeekingBehaviour>().SetTarget(destinationPoints[index].position);
        GetComponent<SeekingBehaviour>().Seek();
    }


}*/
