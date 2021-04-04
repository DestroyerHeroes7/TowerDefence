using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float speed;

    public static int damage = 20;
    public List<Tower> towersCanTargetMe;

    public int hp;

    void Start()
    {
        transform.DOMoveZ(LevelManager.Instance.enemyFinishPoint.position.z, speed).SetSpeedBased()
        .OnComplete(() =>
        {
            LevelManager.Instance.OnPlayerGetDamage();
            Destroy(gameObject);
        });
    }
    public void OnTowerInRange(Tower tower)
    {
        towersCanTargetMe.Add(tower);
    }
    public void OnTowerOutRange(Tower tower)
    {
        towersCanTargetMe.Remove(tower);
    }
    public void GetDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            towersCanTargetMe.ForEach(x => x.OnEnemyDead(this));
            Destroy(gameObject);
        }
    }
}
