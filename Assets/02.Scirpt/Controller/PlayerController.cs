using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private bool IsMove = false;
    private bool IsFocus = false;
    Animator anim;
    private Rigidbody2D rb;
    public NpcInfoes npc = null;
    private Vector2 pos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    public void OnMove(InputValue value)
    {
        if (!GameManager.Instance.isPlaying)
        {
            CallMoveEvent(Vector2.zero);
            return;
        }
        if(!IsMove) 
        {
            IsMove = true;
            anim.SetBool("IsMove", true);
        }
        
        Vector2 moveInput = value.Get<Vector2>().normalized;
        pos = moveInput;    
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        if (IsMove || !GameManager.Instance.isPlaying || !IsFocus)
            return;
        Vector2 lookInput;
        if (value == null)
        {
            lookInput = Vector2.zero;
        }
        else
        {
            lookInput = value.Get<Vector2>();
        }
        CallLookEvent(lookInput);
    }


    public void OnInteraction(InputValue value)
    {
        if(value.isPressed && npc != null)
            CallOnInterationEvent();
    }

    private void FixedUpdate()
    {
        if (pos == Vector2.zero)
        {
            Debug.Log("moveFalse");
            IsMove= false;
            anim.SetBool("IsMove", false);

        }
        else
        {
            Debug.Log("movetrue");
            anim.SetBool("IsMove", true);
        }

    }

    private void OnApplicationFocus(bool hasFocus)
    {
        IsFocus = hasFocus;
    }
}
