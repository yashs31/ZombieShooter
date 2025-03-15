using UnityEngine;
public class PrimaryBullet : BulletBase
{
    private int _enemyLayer;
    private int _boundaryLayer;
    private void Awake()
    {
        _enemyLayer = LayerMask.NameToLayer(ENEMY_LAYER);
        _boundaryLayer = LayerMask.NameToLayer(BOUNDARY_LAYER);
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
        if (collision.gameObject.layer == _boundaryLayer)
        {
            this.gameObject.SetActive(false);
        }
    }

}
