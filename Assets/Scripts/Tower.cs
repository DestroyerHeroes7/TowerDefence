using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentSpot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TowerSpot"))
        {
            currentSpot = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TowerSpot"))
        {
            currentSpot = null;
        }
    }
    public void GoToSpot()
    {
        currentSpot.GetComponent<BoxCollider>().enabled = false;
        transform.position = currentSpot.position + Vector3.up * 0.5f;
    }
}
