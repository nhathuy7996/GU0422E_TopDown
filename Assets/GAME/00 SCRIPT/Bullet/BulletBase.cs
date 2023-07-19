using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class BulletBase : MonoBehaviour
{

    [SerializeField] protected float _speed, _dmg, _lifeTime;
    [SerializeField] protected Rigidbody2D _rigi;

    protected Vector2 _movement = Vector2.zero;

    TrailRenderer _trail;

    Coroutine routineAutoDestruct;
    // Start is called before the first frame update
    void Start()
    {
        if (_rigi == null)
            _rigi = this.GetComponent<Rigidbody2D>();

        this._trail = this.GetComponent<TrailRenderer>();
    }

    public void Init(float speed, float dmg, float lifeTime, Vector2 movement)
    {
        this._speed = speed;
        this._dmg = dmg;
        this._lifeTime = lifeTime;
        this._movement = movement;

        this._trail.Clear();
    }

    void OnEnable() {
        routineAutoDestruct = StartCoroutine(autoDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        //this._lifeTime -= Time.deltaTime;
        //if (this._lifeTime < 0)
        //    this.gameObject.SetActive(false);
    }

    IEnumerator autoDestruct() {
        yield return new WaitForSeconds(this._lifeTime);

        this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        _rigi.velocity = _movement * _speed;
    }

    protected abstract void Boom(GameObject target);

    private void OnDisable()
    {
        _rigi.velocity = Vector2.zero;

        if (routineAutoDestruct != null)
            StopCoroutine(routineAutoDestruct);
    }

   
}
