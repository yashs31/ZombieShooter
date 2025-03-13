public class LittleZombie : EnemyBase, IUnitAnimations
{
    void Start()
    {
        RigidBody2D.velocity = -transform.right * _statsSO.MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Hurt()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }
}
