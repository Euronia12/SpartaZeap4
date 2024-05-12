using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAimRotation : MonoBehaviour
{


    public Animator m_Animator;
    CharacterController _controller;
    private Define.eMyDirection dir;
    private void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _controller.OnLookEvent += newAimDirection;
    }

    private void newAimDirection(Vector2 direction)
    { 
        RotateCharacter(direction, "Horizontal", "Vertical");
    }
    
    private void RotateCharacter(Vector2 direction, string first, string second)
    {
        dir = _controller.CheckedDirection(direction);
        switch (dir) 
        {
            case Define.eMyDirection.North:
                m_Animator.SetFloat(first, 0.5f);
                m_Animator.SetFloat(second, 1);
                break;
            case Define.eMyDirection.South:
                m_Animator.SetFloat(first, 0.5f);
                m_Animator.SetFloat(second, 0);
                break;
            case Define.eMyDirection.West:
                m_Animator.SetFloat(first, 0);
                m_Animator.SetFloat(second, 0.5f);
                break;
            case Define.eMyDirection.East:
                m_Animator.SetFloat(first, 1);
                m_Animator.SetFloat(second, 0.5f);
                break;
        }
    }
}
