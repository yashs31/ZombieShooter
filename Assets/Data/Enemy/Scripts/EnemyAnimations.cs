using UnityEngine;

public static class EnemyAnimations
{
    public static string WALK_STATE = "walk";
    public static string HURT_STATE = "hurt";
    public static string ATTACK_STATE = "attack";
    public static string DIE_STATE = "death_01";
    public static string IDLE_STATE = "idle";
    public static readonly int ENEMY_WALK = Animator.StringToHash(WALK_STATE);
    public static readonly int ENEMY_HURT = Animator.StringToHash(HURT_STATE);
    public static readonly int ENEMY_ATTACK = Animator.StringToHash(ATTACK_STATE);
    public static readonly int ENEMY_DIE = Animator.StringToHash(DIE_STATE);
    public static readonly int ENEMY_IDLE = Animator.StringToHash(IDLE_STATE);
}
