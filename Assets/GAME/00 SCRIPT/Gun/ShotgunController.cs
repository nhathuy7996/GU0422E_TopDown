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

        BulletBase bulletInstant = ObjectPooling.Instant.Getcomp(_bullet);
         
        bulletInstant.Init(_bulletSpeed, _bulletDamage, _lifeTime, movement);
        bulletInstant.transform.position = this.transform.position;
        bulletInstant.gameObject.SetActive(true);
        
        

        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

        float anglePerBullet = _maxAngle / _numberBulletPerShot;
        float lefAngel = angle;
        float rightAngle = angle;

        for (int i = _numberBulletPerShot / 2; i > 0; i--) {

            lefAngel -= anglePerBullet;
            movement.x = Mathf.Cos(lefAngel * Mathf.Deg2Rad);
            movement.y = Mathf.Sin(lefAngel * Mathf.Deg2Rad);

            bulletInstant = ObjectPooling.Instant.Getcomp(_bullet);

            bulletInstant.Init(_bulletSpeed, _bulletDamage, _lifeTime, movement);
            bulletInstant.transform.position = this.transform.position;
            bulletInstant.gameObject.SetActive(true);

        }

        for (int i = _numberBulletPerShot / 2; i < _numberBulletPerShot-1; i++)
        {

            rightAngle += anglePerBullet;
            movement.x = Mathf.Cos(rightAngle * Mathf.Deg2Rad);
            movement.y = Mathf.Sin(rightAngle * Mathf.Deg2Rad);

            bulletInstant = ObjectPooling.Instant.Getcomp(_bullet);

            bulletInstant.Init(_bulletSpeed, _bulletDamage, _lifeTime, movement);
            bulletInstant.transform.position = this.transform.position;
            bulletInstant.gameObject.SetActive(true);

        }


        _timer = _coolDownTime;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
    }
}
