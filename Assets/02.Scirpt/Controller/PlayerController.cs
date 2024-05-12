using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private Camera _camera;
    private bool IsMove = false;
    Animator anim;
    private Rigidbody2D rb;
    private void Awake()
    {
        _camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    public void OnMove(InputValue value)
    {
        if (!GameManager.Instance.isPlaying)
        {
            return;
        }
        IsMove = true;
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        if (!GameManager.Instance.isPlaying || IsMove)
        {
            return;
        }
        Vector2 lookInput= value.Get<Vector2>();
        CallLookEvent(lookInput);
    }

    public void OnInteraction(InputValue value)
    {
        CallOnInterationEvent();
    }

    private void FixedUpdate()
    {
        if (rb.velocity == Vector2.zero)
        {
            IsMove= false;
            anim.SetBool("IsMove", false);
        }
        else
        {
            anim.SetBool("IsMove", true);
        }

    }
}
