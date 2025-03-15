using UnityEngine;

public static class PlayerAnimations
{
    public static string DUMMY = "Dummy";
    public static string IDLE_STATE = "Idle";
    public static string ATTACK_STATE = "Attack";
    public static string HURT_STATE = "Attack";
    public static string DIE_STATE = "Die";
    public static string WALK_STATE = "Run";

    public static readonly int HERO_DUMMY = Animator.StringToHash(DUMMY);
    public static readonly int HERO_IDLE = Animator.StringToHash(IDLE_STATE);
    public static readonly int HERO_HURT = Animator.StringToHash(HURT_STATE);
    public static readonly int HERO_ATTACK = Animator.StringToHash(ATTACK_STATE);
    public static readonly int HERO_DIE = Animator.StringToHash(DIE_STATE);
    public static readonly int HERO_WALK = Animator.StringToHash(WALK_STATE);
}
