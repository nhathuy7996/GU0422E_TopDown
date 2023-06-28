using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    PlayerController _player;
    [SerializeField] BulletBase _bullet;

    [SerializeField] float _bulletSpeed, _bulletDamage, _lifeTime, _coolDownTime;

    float _timer = 0;

    public void Init(PlayerController player) {
        this._player = player;
        _timer = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void Fire() {
        if (_timer > 0)
            return;
         
        Instantiate<BulletBase>(_bullet, this.transform.position, Quaternion.identity).
                 Init(_bulletSpeed, _bulletDamage, _lifeTime, _player.transform.right);
        
        _timer = _coolDownTime;

    }

    public void ChangeBullet(BulletBase newBullet) {
        this._bullet = newBullet;
    }
}
