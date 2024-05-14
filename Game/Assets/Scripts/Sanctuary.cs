using System.Collections;
using UnityEngine;

public class Sanctuary : MonoBehaviour, IUsable
{
    private bool Enter;
    public void Use()
    {
        OpenSanctuary();
    }

    private void OpenSanctuary()
    {
        Invertory invertory = Invertory.Instance;
        invertory.ResetEquipItem();
        invertory.OnSanctuaryOpen();
        Enter = !Enter;
        if (Enter)
        {
            Movement.Instance.Freeze();
            if(!invertory.Once)invertory.InventoryOpenAndClose();
            invertory.EquipButton.SetActive(true);
        }
        else
        {
            Movement.Instance.UnFreeze();
            invertory.InventoryOpenAndClose();
            invertory.EquipButton.SetActive(false);
        }
    }
}
