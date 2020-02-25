using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public string itemName;
    public Transform invisibleCard;

    public void OnBeginDrag (PointerEventData eventData){
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(invisibleCard, true);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData){
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(transform.parent.GetComponent<Slot>()!=null){
            return;
        }
        else if(transform.parent != startParent){
            transform.SetParent(startParent);
            transform.position = startPosition;
        }
    }
}