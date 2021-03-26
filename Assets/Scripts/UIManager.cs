using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform test;
    public RaycastHit hit;

    public LayerMask mask;

    public bool isHold;
    void Update()
    {
        if (isHold)
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask);
        }
    }
    public void OnButtonDown()
    {
        isHold = true;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, mask);
    }
    public void OnButtonUp()
    {
        isHold = false;
    }
}
