using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeAmulet : Item
{
    [SerializeField] private int MaxHealth = 120;
    private int DefaultHealth = 100;
    private void Start() => Id = 1;
    public override void OnStartInventoryUse()
    {
        Movement.Instance.GetComponent<Health>().SetMaxHealth(MaxHealth);
    }
    public override void OnPullOut()
    {
        Movement.Instance.GetComponent<Health>().SetMaxHealth(DefaultHealth);
        if (Movement.Instance.GetComponent<Health>().GetHealth() > 100) Movement.Instance.ApplyDamage(20);
    }
}
