using System;
using UnityEngine;

public class Attack : StateMachineBehaviour
{
    public static Action OnStartAttack;
    public static Action OnAttack;
    public static Action OnEndAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnStartAttack.Invoke();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnAttack.Invoke();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEndAttack.Invoke();
    }
}
