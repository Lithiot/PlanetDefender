using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool canCharge = true;

    [SerializeField] private float health = 10.0f;

    [SerializeField] public float energy = 10.0f;
    [SerializeField] private float energyConsuption = 1.0f;
    private float currentEnergy = 0.0f;

    public ShieldBehaviour shield;

    public float Health { get => health; }
    public float CurrentEnergy { get => currentEnergy; }

    private void Awake()
    {
        currentEnergy = energy;
        canCharge = true;
    }

    private void Update()
    {
        switch (InputManager.instance.inputState)
        {
            case TouchState.Idle:
                RechargeEnergy();
                break;
            case TouchState.Pressed:
                    ChargeField();
                break;
            case TouchState.Ended:
                ActivateField();
                break;
        }

        if (currentEnergy <= 0)
        {
            canCharge = false;
            OnZeroEnergy();
        }
        else if (!canCharge && currentEnergy >= energy * 0.2)
            canCharge = true;
    }

    private void ChargeField()
    {
        Debug.Log("Charging field");

        if (canCharge)
        {
            shield.Charge();

            if (currentEnergy <= energy * 0.2)
                shield.sprite.color = Color.red;
            else
                shield.sprite.color = Color.white;

            currentEnergy -= energyConsuption * Time.deltaTime;
        }
        else
            RechargeEnergy();
    }

    private void ActivateField()
    {
        Debug.Log("Explosion!");

        shield.Attack();
    }

    private void OnZeroEnergy()
    {
        Debug.Log("Runned out of energy!");

        shield.DisableShield();
    }

    private void RechargeEnergy()
    {
        Debug.Log("Recharging Energy");
        shield.DisableShield();

        if (currentEnergy < energy)
            currentEnergy += energyConsuption * Time.deltaTime;
        else if (currentEnergy > energy)
            currentEnergy = energy;
    }

    public void GetDamaged(float damage)
    {
        health -= damage;

        Camera.main.GetComponent<Animator>().SetTrigger("Shake");

        if (health <= 0)
        {
            Debug.Log("You Died");
            GameManager.instance.GameOver();
        }
    }
}
