using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : GunControllerBase
{
    [Space(50)]
    [Header("------ShotGun Config-------")]
    [SerializeField] int _numberBulletPerShot = 3;
    [SerializeField] float _maxAngle = 45;
    public override void Fire()
    {
       
        if (_timer > 0)
            return;

        Vector2 movement = _player.transform.right;
       
        Instantiate<BulletBase>(_bullet, this.transform.position, Quaternion.identity).
                Init(_bulletSpeed, _bulletDamage, _lifeTime, movement);

        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

        float anglePerBullet = _maxAngle / _numberBulletPerShot;
        float lefAngel = angle;
        float rightAngle = angle;

        for (int i = _numberBulletPerShot / 2; i > 0; i--) {

            lefAngel -= anglePerBullet;
            movement.x = Mathf.Cos(lefAngel * Mathf.Deg2Rad);
            movement.y = Mathf.Sin(lefAngel * Mathf.Deg2Rad);


            Instantiate<BulletBase>(_bullet, this.transform.position, Quaternion.identity).
                 Init(_bulletSpeed, _bulletDamage, _lifeTime, movement);
        }

        for (int i = _numberBulletPerShot / 2; i < _numberBulletPerShot-1; i++)
        {

            rightAngle += anglePerBullet;
            movement.x = Mathf.Cos(rightAngle * Mathf.Deg2Rad);
            movement.y = Mathf.Sin(rightAngle * Mathf.Deg2Rad);


            Instantiate<BulletBase>(_bullet, this.transform.position, Quaternion.identity).
                 Init(_bulletSpeed, _bulletDamage, _lifeTime, movement);
        }


        _timer = _coolDownTime;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
    }
}
