using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : BulletBase
{
    protected override void Boom(GameObject target)
    {
        this.gameObject.SetActive(false);

        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit != null)
        {
            isCanGetHit.GetHit(this._dmg);
        }
    }
    //xyz
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Boom(collision.gameObject);
    }
}
