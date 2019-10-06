using UnityEngine;

public class CharcterAttackStateBehaviour : StateMachineBehaviour
{
    public delegate void OnCharacterAttackDelegate();
    public event OnCharacterAttackDelegate CharacterAttack;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
