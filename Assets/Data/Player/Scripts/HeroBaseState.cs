public abstract class HeroBaseState
{
    protected float _fadeDuration = 0.0f;
    public abstract void EnterState(Hero hero);
    public abstract void UpdateState(Hero hero);
    public abstract void ExitState(Hero hero);
}
