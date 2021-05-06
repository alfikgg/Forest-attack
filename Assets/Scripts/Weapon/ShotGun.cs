using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] private int _spreadAngle;
    [SerializeField] private int _numberBulletsInShot = 1;

    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < _numberBulletsInShot; i++)
        {
            var rotationZ = Quaternion.AngleAxis(Random.Range(-_spreadAngle / 2, _spreadAngle / 2), transform.forward);
            Instantiate(Bullet, shootPoint.position, rotationZ);
        }
    }
}
