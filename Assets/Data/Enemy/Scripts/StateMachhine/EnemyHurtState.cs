using UnityEngine;

public class EnemyHurtState : EnemyBaseState
{
    private AnimatorStateInfo _animatorInfo;
    public override void EnterState(EnemyBase enemy)
    {
        enemy.Animator.CrossFade(EnemyAnimations.ENEMY_HURT, _fadeDuration, 0);
        enemy.StopWalk();
    }

    public override void ExitState(EnemyBase enemy)
    {
    }

    public override void UpdateState(EnemyBase enemy)
    {
        _animatorInfo = enemy.Animator.GetCurrentAnimatorStateInfo(0);
        //wait for end of animation tp switch state
        if (_animatorInfo.IsName(EnemyAnimations.HURT_STATE) && _animatorInfo.normalizedTime >= 1f)
        {
            enemy.SetImmunity(false);
            if (enemy.CurrentHealth <= 0)
            {
                enemy.SwitchState(enemy._deadState);
            }
            else
            {
                enemy.SwitchState(enemy._walkState);
            }
        }

    }
}
