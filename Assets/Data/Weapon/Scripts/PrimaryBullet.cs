using UnityEngine;
public class PrimaryBullet : BulletBase
{
    private int _enemyLayer;
    private void Awake()
    {
        _enemyLayer = LayerMask.NameToLayer(ENEMY_LAYER);
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
            Events.BulletHit.Invoke(_bulletDamage, collision.GetComponent<EnemyBase>());
            this.gameObject.SetActive(false);
        }
    }

}
