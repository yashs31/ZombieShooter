using UnityEngine;

public static class PlayerAnimations
{
    public static string IDLE_STATE = "Idle";
    public static string ATTACK_STATE = "Attack";
    public static string HURT_STATE = "Attack";
    public static string DIE_STATE = "Die";

    public static readonly int HERO_IDLE = Animator.StringToHash(IDLE_STATE);
    public static readonly int HERO_HURT = Animator.StringToHash(HURT_STATE);
    public static readonly int HERO_ATTACK = Animator.StringToHash(ATTACK_STATE);
    public static readonly int HERO_DIE = Animator.StringToHash(DIE_STATE);
}
