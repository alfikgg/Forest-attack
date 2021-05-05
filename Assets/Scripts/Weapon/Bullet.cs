using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _flighRange = 0;

    private float _startPositionX;

    private void Start()
    {
        _startPositionX = transform.position.x;
    }
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        if (_flighRange != 0)
        {
            float maxDistance = Mathf.Abs(_startPositionX - transform.position.x);
            if (maxDistance >= _flighRange)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
        else if (collision.gameObject.TryGetComponent(out Bullet bullet))
            return;
     
        Destroy(gameObject);
    }
}
