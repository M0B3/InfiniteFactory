using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridGenerator.Instance.GenerateGrid();
                break;
            case GameState.GenerateSpawnerAndExit:
                BuildingsSpawnerHandler.Instance.SpawnSpawner();
                break;            
            case GameState.GenerateDepotAndExit:
                BuildingsSpawnerHandler.Instance.SpawnDepot();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public enum GameState
    {
        GenerateGrid = 0,
        GenerateSpawnerAndExit = 1,
        GenerateDepotAndExit = 2
    }
}
