public class HeroDeathState : HeroBaseState
{
    public override void EnterState(Hero hero)
    {
        hero.Animator.CrossFade(PlayerAnimations.DIE_STATE, _fadeDuration, 0);
        hero.Weapon.gameObject.SetActive(false);
    }
    public override void ExitState(Hero hero)
    {
    }

    public override void UpdateState(Hero hero)
    {
    }
}
