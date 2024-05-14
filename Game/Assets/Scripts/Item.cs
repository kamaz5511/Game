using UnityEngine;

public class Item : MonoBehaviour, IUsable, IInventoryUsable
{
    [HideInInspector]public int Id = 0;
    public float CoolDown = 1f;
    [HideInInspector] public bool CanUse = true;
    [Header("Может поместить в слот экипировки?")]
    public bool Usable = true;

    public virtual void InventoryUse()
    {
    }
    public virtual void OnStartInventoryUse()
    {

    }
    public virtual void OnSanctuaryOpen()
    {

    }

    public virtual void OnPullOut()
    {
    }
    public void Use()
    {
        Invertory.Instance.CheckSlots(this);
    }
}
