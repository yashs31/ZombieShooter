public class HeroHurtState : HeroBaseState
{
    public override void EnterState(Hero hero)
    {
        hero.Animator.CrossFade(PlayerAnimations.HURT_STATE, _fadeDuration, 0);
    }

    public override void ExitState(Hero hero)
    {
    }

    public override void UpdateState(Hero hero)
    {
    }
}
