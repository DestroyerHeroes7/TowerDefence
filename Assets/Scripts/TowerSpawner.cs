using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;
    public Transform currentTower;
    public UIManager uiManager;
    public void OnButtonDown()
    {
        currentTower = Instantiate(towerPrefab, uiManager.hit.point + Vector3.up * 0.5f, Quaternion.identity).transform;
    }
    public void OnButtonUp()
    {
        Tower tower = currentTower.GetComponent<Tower>();
        if (tower.currentSpot)
        {
            currentTower = null;
            tower.GoToSpot();
        }
        else
            Destroy(currentTower.gameObject);
    }
    private void Update()
    {
        if (uiManager.isHold)
            currentTower.position = uiManager.hit.point + Vector3.up * 0.5f;
    }
}
