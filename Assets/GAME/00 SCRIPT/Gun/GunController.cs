using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : GunControllerBase
{

    void Update()
    {
        _timer -= Time.deltaTime;
    }

    public override void Fire() {
        if (_timer > 0)
            return;

        Debug.LogError(_bullet.GetType());

        BulletBase bulletInstant = ObjectPooling.Instant.Getcomp<BulletBase> (_bullet);

        bulletInstant.transform.position = this.transform.position;
        bulletInstant.Init(_bulletSpeed, _bulletDamage, _lifeTime, _player.transform.right); 
        bulletInstant.gameObject.SetActive(true);
        _timer = _coolDownTime;

    }
}
