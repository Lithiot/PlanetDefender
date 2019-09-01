using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    public GameObject[] heartContainer;
    public Slider energyUI;
    public GameObject gameOverUI;
    public GameObject inGameUI;

    public PlayerController player;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        UpdateHeartContainer();
        UpdateEnergyBar();
    }

    private void UpdateHeartContainer()
    {
        foreach (GameObject n in heartContainer)
        {
            n.SetActive(false);
        }

        for (int i = 0; i < player.Health; i++)
        {
            heartContainer[i].SetActive(true);
        }
    }

    private void UpdateEnergyBar()
    {
        energyUI.value = player.CurrentEnergy;
    }

    public void TriggerGameOverUI()
    {
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}
