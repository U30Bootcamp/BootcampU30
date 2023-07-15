using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    public MovementController _MovementController;
    public Animator _Animator;

    void FixedUpdate()
    {
        _Animator.SetBool("isFalling",_MovementController.GetIsFalling());
        _Animator.SetBool("isJumping",_MovementController.GetIsJumping());
    }
}
