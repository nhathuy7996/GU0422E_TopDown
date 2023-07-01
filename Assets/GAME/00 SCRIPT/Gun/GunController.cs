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

        GameObject bulletInstant = this.GetBullet();
        if(bulletInstant == null) {
            BulletBase b = Instantiate<BulletBase>(_bullet, this.transform.position, Quaternion.identity);
            b.Init(_bulletSpeed, _bulletDamage, _lifeTime, _player.transform.right);

            this._bulletPooling.Add(b.gameObject);

        }

        bulletInstant.GetComponent<BulletBase>().Init(_bulletSpeed, _bulletDamage, _lifeTime, _player.transform.right);
        bulletInstant.transform.position = this.transform.position;
        bulletInstant.gameObject.SetActive(true);


        _timer = _coolDownTime;

    }

    
}
