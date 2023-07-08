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

        BulletBase bulletInstant = ObjectPooling.Instant.Getcomp<BulletBase>(_bullet);

        bulletInstant.Init(_bulletSpeed, _bulletDamage, _lifeTime, _player.transform.right);
        bulletInstant.transform.position = this.transform.position;
        bulletInstant.gameObject.SetActive(true);
        _timer = _coolDownTime;

    }
}
