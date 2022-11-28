using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBox : MonoBehaviour
{
    public Image box1;
    // Start is called before the first frame update
    private void Start()
    {
        box1.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box1.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box1.enabled = false;
        }
    }
}
