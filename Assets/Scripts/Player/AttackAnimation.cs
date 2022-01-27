using UnityEngine;
using UnityEngine.Events;

public class AttackAnimation : StateMachineBehaviour
{
    public static UnityEvent OnStart = new UnityEvent();
    public static UnityEvent OnUpdate = new UnityEvent();
    public static UnityEvent OnEnd = new UnityEvent();

    public static bool IsAttack { get; private set; }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnStart.Invoke();
        IsAttack = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnUpdate.Invoke();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEnd.Invoke();
        IsAttack = false;
    }
}
