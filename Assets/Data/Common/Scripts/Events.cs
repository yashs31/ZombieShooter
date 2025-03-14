using System;

public static class Events
{
    public static Action<float, EnemyBase> BulletHit;
    public static Action<float> PlayerHit;
    public static Action<EnemyBase> EnemyDead;
    public static Action<int, int> UpdateZombieCount;
    public static Action<int> UpdateWaveCount;
    public static Action<int, int> UpdateAmmoCount;
    public static Action<bool> ReloadToggled;
}
