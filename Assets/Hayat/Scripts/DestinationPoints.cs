using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DestinationPoints : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);
    }


}
