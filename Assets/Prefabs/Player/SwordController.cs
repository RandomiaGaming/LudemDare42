using UnityEngine;
public enum SwordState { Idle, Attacking, EXAttacking };
public class SwordController : MonoBehaviour
{
    public AttackBox mainAttackBox;
    public AttackBox exAttackBox;

    private ParticleSystem particleSystem;
    private Animator playerAnimator;

    private SwordState swordState = SwordState.Idle;
    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        int mainLayerIndex = playerAnimator.GetLayerIndex("Main Layer");
        AnimatorStateInfo currentAnimatorState = playerAnimator.GetCurrentAnimatorStateInfo(mainLayerIndex);
        if (currentAnimatorState.IsName("Attack"))
        {
            swordState = SwordState.Attacking;
        }
        else if (currentAnimatorState.IsName("EX Attack"))
        {
            swordState = SwordState.EXAttacking;
        }
        else if (currentAnimatorState.IsName("Idle"))
        {
            swordState = SwordState.Idle;
        }

        if (Input.GetKeyDown(KeyCode.J) && swordState == SwordState.Idle)
        {
            swordState = SwordState.EXAttacking;
            playerAnimator.Play("EX Attack");
        }

        if (swordState == SwordState.Attacking)
        {
            mainAttackBox.active = true;
        }
        else
        {
            mainAttackBox.active = false;
        }

        if (swordState == SwordState.EXAttacking)
        {
            exAttackBox.active = true;
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            exAttackBox.active = false;
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }
    public SwordState GetSwordState()
    {
        return swordState;
    }
}
