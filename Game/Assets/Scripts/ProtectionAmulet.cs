using UnityEngine;

public class ProtectionAmulet : Item
{
    private void Start() => Id = 3;
    public override void OnStartInventoryUse()
    {
        Movement.Instance.GetComponent<Health>().Amulet = true;
    }
    public override void OnPullOut()
    {
        Movement.Instance.GetComponent<Health>().Amulet = false;
    }
}