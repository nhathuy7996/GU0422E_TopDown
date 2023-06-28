using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : BulletBase
{
   
    int _countTarget;

    protected override void Boom(GameObject target)
    {

        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit == null)
        {
            Destroy(this.gameObject);
            return;
        }

        isCanGetHit.GetHit(this._dmg);
        this._dmg /= 2f;
        this._speed /= 2f;

        if (_countTarget >= 2)
            Destroy(this.gameObject);
        _countTarget++;
    }

    // Start is called before the first frame update


    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Boom(collision.gameObject);
    }
}
