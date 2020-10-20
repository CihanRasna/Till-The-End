using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int isGameLose = Animator.StringToHash("isGameLose");
    private static readonly int isRunning = Animator.StringToHash("isRunning");

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(isRunning,PlayerManager.Speed);

        if (PlayerManager.isGameLose)
        {
            animator.SetFloat(isRunning,0);
        }
        animator.SetBool(isGameLose,PlayerManager.isGameLose);
        
    }

}
