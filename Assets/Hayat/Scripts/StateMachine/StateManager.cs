using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    //THIS VARIABLE IS  
    
    State currentState;
    private void Update()
    {
        State next = currentState.RunState();
        if( next!= null)
        {
            currentState = next;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.enabled = false;
            GetComponent<Inspecting>().enabled = true;
            //GetComponent<PatrolingState>().collided =true;
        }
    }

}
