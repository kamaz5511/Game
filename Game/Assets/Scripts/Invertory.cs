using System.Collections;
using UnityEngine;

public class Invertory : MonoBehaviour
{

    public GameObject InventoryBox, EquipButton;
    [HideInInspector] public Slot Previous;
    public static Invertory Instance { get; private set; }
    [SerializeField]private Slot[] Slots;
    [SerializeField]private Slot EquipmentSlot;

    [HideInInspector]public bool Once;
    [HideInInspector] public Item SlotContent { private get; set; }
    private bool Inventoryfull = false;

    private void Awake() => Instance = this;


    public void CheckSlots(Item item)
    {
        bool placed = false;
        for (int i = 0; i < Slots.Length; i++) 
        {
            if (!Slots[i].Full && !placed)
            {
                Inventoryfull = false;
                Slots[i].Put(item);
                placed = true;
            }else if(Slots[i].Full)
            {
                Inventoryfull=true;
            }
        }
    }

    public void MoveToEqupmentSlot()
    {
        if (SlotContent != null && SlotContent.Usable)
        {
            if (!EquipmentSlot.Full)
            {
                EquipmentSlot.Put(SlotContent);
                Previous.ClearSlot();
                EquipmentSlot.ItemInSlot.OnStartInventoryUse();
            }
        }
    }
    public void PullOut()
    {
        if (EquipmentSlot.Full)
        {
         CheckSlots(EquipmentSlot.ItemInSlot);
            if (!Inventoryfull)
            {
                EquipmentSlot.ItemInSlot.OnPullOut();
                EquipmentSlot.ClearSlot();
            }
        }
    }

    public void CheckOrder()
    {
        Slot previus = null;
        for (int i = 0; i < Slots.Length; i++)
        {
            if(previus != null)
            {
                if(previus.Full != Slots[i].Full)
                {
                    if (!previus.Full)
                    {
                        previus.Put(Slots[i].ItemInSlot);
                        Slots[i].ClearSlot();
                    }
                }
            }
            previus = Slots[i];
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) )
        {

            InventoryOpenAndClose();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(UseEquipItem());
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            FindItemInSlotbyId(5);
        }
    }

    private IEnumerator UseEquipItem()
    {
        if(EquipmentSlot.ItemInSlot == null)
        {
            yield break;
        }
        yield return new WaitForSeconds(EquipmentSlot.ItemInSlot.CoolDown);
        EquipmentSlot.ItemInSlot.InventoryUse();
        yield break;
    }
    public void InventoryOpenAndClose()
    {
        Once = !Once;
        if (Once)
        {
            InventoryBox.GetComponent<Animator>().SetBool("IsOpen", true);
            Movement.Instance.Freeze();
        }
        else
        {
            InventoryBox.GetComponent<Animator>().SetBool("IsOpen", false);
            EquipButton.SetActive(false);
            Movement.Instance.UnFreeze();
        }
    }

    public void ResetEquipItem()
    {
        if(EquipmentSlot.ItemInSlot != null) EquipmentSlot.ItemInSlot.CanUse = true;
    }
    public void OnSanctuaryOpen()
    {
        if (EquipmentSlot.ItemInSlot != null) EquipmentSlot.ItemInSlot.OnSanctuaryOpen();
    }
    public Slot FindItemInSlotbyId(int itemId)
    {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].ItemInSlot != null)
                {
                    if (Slots[i].ItemInSlot.Id == itemId)
                    {
                        return Slots[i];
                    }
                }
        }
        return null;
    }
}
