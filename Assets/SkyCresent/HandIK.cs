using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : MonoBehaviour
{
    Animator animator;
    public Transform target;
    public AvatarIKGoal avatarIKGoal;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnAnimatorIK()
    {
        animator.SetIKPositionWeight(avatarIKGoal,1f);
        animator.SetIKRotationWeight(avatarIKGoal,1f);

        animator.SetIKPosition(avatarIKGoal, target.position);
        animator.SetIKRotation(avatarIKGoal, target.rotation);
    }
}
