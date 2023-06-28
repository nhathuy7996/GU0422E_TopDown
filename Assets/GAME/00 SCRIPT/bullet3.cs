using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet3 : BulletBase
{
    [SerializeField] Collider2D _extendDmgArea;
    protected override void Boom(GameObject target)
    {
        Destroy(this.gameObject);
        _extendDmgArea.enabled = true;

        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit == null)
        { 
            return;
        }

        isCanGetHit.GetHit(_dmg);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Boom(collision.gameObject);
    }
}
