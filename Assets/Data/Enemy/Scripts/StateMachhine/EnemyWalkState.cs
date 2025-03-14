public class EnemyWalkState : EnemyBaseState
{
    public override void EnterState(EnemyBase enemy)
    {
        enemy.StartWalk();
        enemy.Animator.CrossFade(EnemyAnimations.ENEMY_WALK, _fadeDuration, 0);

    }

    public override void ExitState(EnemyBase enemy)
    {
    }

    public override void UpdateState(EnemyBase enemy)
    {
    }
}
