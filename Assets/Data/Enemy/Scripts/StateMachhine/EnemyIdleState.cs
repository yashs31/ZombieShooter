using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private AnimatorStateInfo _animatorInfo;
    public override void EnterState(EnemyBase enemy)
    {
        enemy.Animator.CrossFade(EnemyAnimations.ENEMY_IDLE, _fadeDuration, 0);
        enemy.StopWalk();
    }

    public override void ExitState(EnemyBase enemy)
    {

    }

    public override void UpdateState(EnemyBase enemy)
    {
        _animatorInfo = enemy.Animator.GetCurrentAnimatorStateInfo(0);
        //wait for end of animation tp switch state
        if (_animatorInfo.IsName(EnemyAnimations.IDLE_STATE) && _animatorInfo.normalizedTime >= 1f)
        {
            enemy.SwitchState(enemy._attackState);
        }
    }
}
