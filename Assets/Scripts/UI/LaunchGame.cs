using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    
    private void Awake()
    {
        Time.timeScale = 0;
        _startPanel.SetActive(true);
    }
}
