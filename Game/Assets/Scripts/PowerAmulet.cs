using UnityEngine;
public class PowerAmulet : Item
{
    [SerializeField] private int Damage = 10;
    private int SavedDamage;

    private void Start() => Id = 2;
    public override void OnStartInventoryUse()
    {
        Movement instance = Movement.Instance;
        SavedDamage = instance.Damage;
        instance.Damage =+ Damage;
    }
    public override void OnPullOut()
    {
        Movement instance = Movement.Instance;
        instance.Damage = SavedDamage;
    }
}
