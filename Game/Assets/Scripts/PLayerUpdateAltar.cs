using UnityEngine;

public class PLayerUpdateAltar : MonoBehaviour, IUsable
{
    private int[] Id = { 5, 6 };
    private int Damage = 5, Health = 25;
    public void Use()
    {
        Slot slot0 = Invertory.Instance.FindItemInSlotbyId(Id[0]);
        Slot slot1 = Invertory.Instance.FindItemInSlotbyId(Id[1]);
        if (slot0 != null)
        {
            ImprovePower(slot0);
        }else if (slot1 != null)
        {
            ImproveHealth(slot1);
        }
    }

    private void ImproveHealth(Slot slot)
    {
        Movement.Instance.SetMaxHealth(Movement.Instance.GetMaxHealth() + Health);
        slot.ClearSlot();
    }
    private void ImprovePower(Slot slot)
    {
        Movement.Instance.Damage += Damage;
        slot.ClearSlot();
    }
}
