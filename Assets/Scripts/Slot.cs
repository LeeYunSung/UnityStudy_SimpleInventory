using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Subject 
public class Slot : MonoBehaviour, IDropHandler
{
    public Item item{
        get{
            return transform.GetComponentInChildren<Item>();
        }
    }
    Inventory inventory;
    public void Register(Inventory i) {
        inventory = i;
    }
    public void OnDrop(PointerEventData eventData) {
        if(!item) {
            Item.itemBeingDragged.transform.SetParent(transform);
            if (inventory){
                inventory.HasChanged();
            }
        }
    }
}