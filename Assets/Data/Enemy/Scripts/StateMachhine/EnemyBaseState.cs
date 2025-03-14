public abstract class EnemyBaseState
{
    protected float _fadeDuration = 0.0f;
    public abstract void EnterState(EnemyBase enemy);
    public abstract void UpdateState(EnemyBase enemy);
    public abstract void ExitState(EnemyBase enemy);
}
