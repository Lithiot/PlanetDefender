using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : GenericSingleton<GameManager>
{
    public GameObject player;
    public bool isGameOver = false;

    public override void Awake()
    {
        base.Awake();
    }

    public void GameOver()
    {
        isGameOver = true;
        UIManager.instance.TriggerGameOverUI();
    }
}
