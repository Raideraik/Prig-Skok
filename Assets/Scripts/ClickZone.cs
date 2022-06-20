using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickZone : MonoBehaviour, IPointerClickHandler , IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction Click;

    [SerializeField] private Ball _ball;

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _ball.TouchDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _ball.TouchUp();
    }
}
