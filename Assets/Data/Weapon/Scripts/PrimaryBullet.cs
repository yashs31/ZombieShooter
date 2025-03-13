using UnityEngine;
public class PrimaryBullet : BulletBase
{
    // Start is called before the first frame update
    private int _enemyLayer;
    private void Awake()
    {
        _enemyLayer = LayerMask.NameToLayer(ENEMY_LAYER);
        Initialize();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _enemyLayer)
        {
            Debug.Log("EnemyHit");
        }
    }
}
