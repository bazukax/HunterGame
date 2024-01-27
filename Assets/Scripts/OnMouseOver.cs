using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class OnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private UnityEvent OnMouseHover;
    [SerializeField] private UnityEvent OnMouseExitEvent;
    public void OnPointerEnter(PointerEventData ped)
    {
        OnMouseHover.Invoke();
    }
    public void OnPointerExit(PointerEventData ped)
    {
        OnMouseExitEvent.Invoke();
    }
}
