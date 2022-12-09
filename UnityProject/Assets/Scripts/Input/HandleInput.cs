using System;
using UnityEngine;

public class HandleInput : MonoBehaviour
{
    public Action OnBackKeyDown;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackKeyDown?.Invoke();
        }
    }
}
