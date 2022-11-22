using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanAgression : MonoBehaviour
{

    public List<PeasantBees> seekingbees = new ();
    [SerializeField] Transform obstacleposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (seekingbees.Count > 3)
        {
            return;
        }
        if (other.CompareTag("PeassantBees"))
        {
            var bee = other.GetComponent<PeasantBees>();

            if (bee != null)
            {
                bee.obstacle = this.obstacleposition;
                seekingbees.Add(bee);
            }

        }

    }
}
