public class BigZombie : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D.velocity = -transform.right * _statsSO.MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
