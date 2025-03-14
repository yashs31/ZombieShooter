public class HeroIdleState : HeroBaseState
{
    public override void EnterState(Hero hero)
    {
        hero.Animator.CrossFade(PlayerAnimations.IDLE_STATE, _fadeDuration, 0);
    }

    public override void ExitState(Hero hero)
    {
    }

    public override void UpdateState(Hero hero)
    {
    }
}
