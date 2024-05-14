using UnityEngine;

public class CameliaTearsAmulet : Item
{
    private void Start() => Id = 4;
    public override void OnSanctuaryOpen()
    {
        GameManager.Instance.CanRevive = CanUse;
    }
}
