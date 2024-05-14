using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [Header("HealthSYS")]
    [SerializeField]private int HealthCount,MaxHealth = 100;
    [SerializeField] private bool IsPlayer = false;
    [HideInInspector] public bool Block = false, IdealParryTiming = false, Amulet = false;
    [HideInInspector] public int BlocPercentage = 20, Difference;
    public abstract void OnDamaged(int damage);


    private void Start()
    {
        HealthCount = MaxHealth;
    }
    public int GetHealth()
    {
        return HealthCount;
    }
    public int GetMaxHealth()
    {
        return MaxHealth;
    }
    public void ApplyDamage(int damage)
    {
        if (HealthCount > 0)
        {
            if (Block)
            {
                damage /= 2;
                if (IdealParryTiming)
                {
                    damage = 0;
                }
            }
            if (Amulet)
            {
                damage -= (damage * BlocPercentage) / 100;
            }
            HealthCount -= damage;
            if (HealthCount <= 0)
            {
                HealthCount = 0;
                Death();
            }
            if (IsPlayer) HealtDisplay.Instance.Display(HealthCount, MaxHealth);
        }
        OnDamaged(damage);
    }

    public void SetMaxHealth(int maxhealth)
    {
       Difference = maxhealth - MaxHealth;
        MaxHealth = maxhealth;
        if (IsPlayer)
        {
            Heal(Difference);
            HealtDisplay.Instance.Display(HealthCount, MaxHealth);
        }
    }
    private void Death()
    {
        if (IsPlayer)
        {
            SceneManagment.Instance.RestartLevel();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void Heal(int healcount)
    {
        if (HealthCount < MaxHealth)
        {
            HealthCount += healcount;
            if(HealthCount > MaxHealth)
            {
                HealthCount = MaxHealth;
            }
            if (IsPlayer) HealtDisplay.Instance.Display(HealthCount, MaxHealth);
        }
    }
}
