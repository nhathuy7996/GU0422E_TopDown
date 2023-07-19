using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunControllerBase : MonoBehaviour
{
   
    protected PlayerController _player;
    [Header("------Base Config--------")]
    [SerializeField] protected BulletBase _bullet;

    [SerializeField]protected float _bulletSpeed, _bulletDamage, _lifeTime, _coolDownTime;

    protected float _timer = 0;

    protected List<GameObject> _bulletPooling = new List<GameObject>();

    public virtual void Init(PlayerController player)
    {
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
        if(_timer > 0)
            _timer -= Time.deltaTime;
    }

    public abstract void Fire();

    public virtual void ChangeBullet(BulletBase newBullet)
    {
        this._bullet = newBullet;
    }

    protected virtual GameObject GetBullet() {
        foreach (GameObject g in _bulletPooling) {
            if (g.activeSelf)
                continue;

            return g;
        }

        return null;
    }
}
