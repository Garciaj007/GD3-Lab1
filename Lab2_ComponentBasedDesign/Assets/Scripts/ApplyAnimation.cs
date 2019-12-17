using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAnimation : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = aoc;
        aoc["Attack"] = clip;
    }
}
