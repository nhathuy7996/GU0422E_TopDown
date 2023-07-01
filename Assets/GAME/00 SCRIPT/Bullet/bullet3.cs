using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet3 : BulletBase
{
    [SerializeField] Collider2D _extendDmgArea;
    protected override void Boom(GameObject target)
    {
        this.gameObject.SetActive(false);
        _extendDmgArea.enabled = true;

        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit == null)
        { 
            return;
        }

        isCanGetHit.GetHit(_dmg);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Boom(collision.gameObject);
    }
}
