using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollinating : MonoBehaviour
{
    public ParticleSystem pollen;
    // Start is called before the first frame update
    void Start()
    {
        pollen.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PeassantBees"))
        {
          pollen.Play(); 
        }
    }
}
