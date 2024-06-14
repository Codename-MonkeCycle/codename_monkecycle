using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameSTateChanged;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Menu:
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTurn:
                HandleEnemyTurn();
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameSTateChanged?.Invoke(newState);
    }

    private void HandleEnemyTurn()
    {
        throw new NotImplementedException();
    }

    private void HandlePlayerTurn()
    {
        throw new NotImplementedException();
    }

    public enum GameState
    {
        Menu,
        PlayerTurn,
        EnemyTurn,
        Victory,
        Lose
    }
}
