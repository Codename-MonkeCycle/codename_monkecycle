using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private TextMeshProUGUI _stateText;

    private void Awake()
    {
        GameManager.OnGameSTateChanged += GameManagerOnGameSTateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameSTateChanged -= GameManagerOnGameSTateChanged;
    }
    private void GameManagerOnGameSTateChanged(GameManager.GameState state)
    {
        _mainMenu.SetActive(state == GameManager.GameState.Menu);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
