using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float speed;
    void Start()
    {
        transform.DOMoveZ(LevelManager.Instance.enemyFinishPoint.position.z, speed).SetSpeedBased();
    }
    void Update()
    {
        
    }
}
