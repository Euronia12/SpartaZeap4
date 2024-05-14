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
    [SerializeField]
    private DialogueManager dialogue;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();        
    }
    private void Start()
    {
        
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

    private void Update()
    {
        if (!GameManager.Instance.isPlaying)
        {
            return;
        }
        if (rb.velocity == Vector2.zero)
        {
            IsMove = false;
            anim.SetBool("IsMove", false);
        }
        else
        {
            anim.SetBool("IsMove", true);
        }
    }
    public void OnInteraction(InputValue value)
    {
        if(value.isPressed && npc != null && !dialogue.IsTyping)
            CallOnInterationEvent();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        IsFocus = hasFocus;
    }
}
