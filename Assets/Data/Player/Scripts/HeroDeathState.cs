using UnityEngine;

public class HeroDeathState : HeroBaseState
{
    AnimatorStateInfo _animatorInfo;
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
        _animatorInfo = hero.Animator.GetCurrentAnimatorStateInfo(0);
        //wait for end of animation tp switch state
        if (_animatorInfo.IsName(PlayerAnimations.DIE_STATE) && _animatorInfo.normalizedTime >= 1f)
        {
            hero.SwitchState(null);
            hero.PostDeath();
            Events.GameEnd?.Invoke();
        }
    }
}
