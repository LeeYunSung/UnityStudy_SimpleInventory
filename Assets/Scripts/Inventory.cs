using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Observer
public class Inventory : MonoBehaviour, IHasChanged
{
    [SerializeField] private Transform slots;
    [SerializeField] private Text inventoryText;
    Slot[] slot;

    void Start(){
        slot = slots.GetComponentsInChildren<Slot>();
        foreach(Slot slotSlot in slot){
            slotSlot.Register(this);
        }
    }
    public void HasChanged(){
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");
        foreach (Slot slotSlot in slot){
            if (slotSlot.item){
                string name = slotSlot.item.itemName;
                builder.Append(name);
                builder.Append(" - ");
            }
        }inventoryText.text = builder.ToString();
    }
}
namespace UnityEngine.EventSystems{
    public interface IHasChanged : IEventSystemHandler{
        void HasChanged();
    }
}