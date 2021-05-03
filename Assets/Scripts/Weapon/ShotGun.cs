using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < 3; i++)
        {
            var rotationZ = Quaternion.AngleAxis(Random.Range(-5, 5), transform.forward);
            Instantiate(Bullet, shootPoint.position, rotationZ);
        }
    }
}
