using UnityEngine;

public static class EnemyAnimations
{
    public static readonly int ENEMY_WALK = Animator.StringToHash("walk");
    public static readonly int ENEMY_HURT = Animator.StringToHash("hurt");
    public static readonly int ENEMY_ATTACK = Animator.StringToHash("attack");
    public static readonly int ENEMY_DIE = Animator.StringToHash("death_01");
    public static readonly int ENEMY_IDLE = Animator.StringToHash("idle");
}
