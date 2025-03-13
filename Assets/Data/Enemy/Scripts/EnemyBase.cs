using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected ZombieStatsSO _statsSO;
    [SerializeField] protected Animator _animator;
    public Rigidbody2D RigidBody2D { get; private set; }
    protected int _currentState;

    protected bool _isAttacking;
    protected bool _idle;
    protected bool _isHurt;
    protected bool _isWalking;
    private void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
