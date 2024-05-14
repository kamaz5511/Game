using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector] public bool Full = false;
    private Image image;
    [HideInInspector] public Item ItemInSlot;


    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void Put(Item item)
    {
        ItemInSlot = item;
        if(image != null)image.sprite = item.GetComponent<SpriteRenderer>().sprite;
        Full = true;
        item.transform.position = transform.position;
    }

    public void ChoseSlotContent()
    {
        if(ItemInSlot != null)
        {
            Invertory.Instance.SlotContent = ItemInSlot;
            Invertory.Instance.Previous = this;
        }
    }
    public void ClearSlot()
    {
        ItemInSlot.transform.position = Invertory.Instance.EquipButton.transform.position;
        ItemInSlot = null;
        if (image != null) image.sprite = null;
        Full = false;
        Invertory.Instance.SlotContent = null;
        Invertory.Instance.CheckOrder();
    }
}
