using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentSpot;

    public List<Enemy> enemiesInRange;

    public Enemy targetEnemy;
    private void FixedUpdate()
    {
        if (enemiesInRange.Count > 0 && targetEnemy == null)
        {
            targetEnemy = enemiesInRange.First();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TowerSpot"))
        {
            currentSpot = other.transform;
        }
        if(other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TowerSpot"))
        {
            currentSpot = null;
        }
        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemiesInRange.Remove(enemy);
            if (enemy == targetEnemy)
                targetEnemy = null;
        }
    }
    public void GoToSpot()
    {
        currentSpot.GetComponent<BoxCollider>().enabled = false;
        transform.position = currentSpot.position + Vector3.up * 0.5f;
    }
}
