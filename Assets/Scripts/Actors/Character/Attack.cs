using UnityEngine;
using UnityEngine.Events;

public class Attack : StateMachineBehaviour
{
    public static UnityEvent OnStartAttack = new UnityEvent();
    public static UnityEvent OnAttack = new UnityEvent();
    public static UnityEvent OnEndAttack = new UnityEvent();

    public static bool IsAttack { get; private set; }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnStartAttack.Invoke();
        IsAttack = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnAttack.Invoke();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEndAttack.Invoke();
        IsAttack = false;
    }
}
