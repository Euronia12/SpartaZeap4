using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnInteractionEvent;
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction) 
    {
        OnLookEvent?.Invoke(direction);
        
    }

    public void CallOnInterationEvent()
    {
        OnInteractionEvent?.Invoke();
    }

    public Define.eMyDirection CheckedDirection(Vector2 direction)
    {
        float centerX = Screen.width * 0.5f;
        float centerY = Screen.height * 0.5f;
        float mouseX = direction.x - centerX;
        float mouseY = direction.y - centerY;

        if (mouseX - mouseY > 0)
        {
            return mouseX >= 0 ? Define.eMyDirection.East : Define.eMyDirection.West;
        }
        else
        {
            return mouseY > 0 ? Define.eMyDirection.North : Define.eMyDirection.South;
        }
    }
}
