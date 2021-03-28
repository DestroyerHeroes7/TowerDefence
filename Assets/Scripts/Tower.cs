using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentSpot;

    public List<Enemy> enemiesInRange;

    public float fireRate;
    public float rangeRadius;

    public int damage;

    public bool isActive;

    public Enemy targetEnemy;
    private void FixedUpdate()
    {
        if (enemiesInRange.Count > 0 && targetEnemy == null && isActive)
        {
            targetEnemy = enemiesInRange.First();
            targetEnemy.OnTowerTarget(this);
            InvokeRepeating("Shoot", 0, fireRate);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TowerSpot"))
        {
            currentSpot = other.transform;
        }
        if(other.CompareTag("Enemy") && isActive)
        {
            enemiesInRange.Add(other.GetComponent<Enemy>());
        }
    }
    public void OnEnemyDead(Enemy enemy)
    {
        enemiesInRange.Remove(enemy);
        if(enemy == targetEnemy)
            targetEnemy = null;
        CancelInvoke("Shoot");
    }
    private void Shoot()
    {
        if(targetEnemy)
            targetEnemy.GetDamage(damage);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TowerSpot"))
        {
            currentSpot = null;
        }
        if(other.CompareTag("Enemy") && isActive)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemiesInRange.Remove(enemy);
            if (enemy == targetEnemy)
            {
                targetEnemy = null;
                CancelInvoke("Shoot");
            }
        }
    }
    private List<Enemy> CheckInRangeEnemy()
    {
        List<Collider> colliders = Physics.OverlapSphere(transform.position, rangeRadius).ToList();
        return colliders.FindAll(x => x.CompareTag("Enemy")).ConvertAll(x => x.GetComponent<Enemy>());
    }
    public void GoToSpot()
    {
        currentSpot.GetComponent<BoxCollider>().enabled = false;
        transform.position = currentSpot.position + Vector3.up * 0.5f;
        isActive = true;
        enemiesInRange.AddRange(CheckInRangeEnemy());
    }
}