using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float speed;

    public List<Tower> towersTargetingMe;

    public int hp;

    void Start()
    {
        transform.DOMoveZ(LevelManager.Instance.enemyFinishPoint.position.z, speed).SetSpeedBased();
    }
    public void OnTowerTarget(Tower tower)
    {
        towersTargetingMe.Add(tower);
    }
    public void GetDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            towersTargetingMe.ForEach(x => x.OnEnemyDead(this));
            Destroy(gameObject);
        }
    }
}
