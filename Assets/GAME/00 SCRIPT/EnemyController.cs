using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IGetHit
{

    float _HP = 100;
    float _armor = 0;

    float _baseDmg = 30;

    Rigidbody2D _rigi;
    Transform _player;

    Vector2 _movement;
    [SerializeField] float _speed;

    [SerializeField] LayerMask _layerMask, _playerLayerMask;
    [SerializeField] float _detectTargetRadius;
    GameManager gameM;

 
    // Start is called before the first frame update
    void Awake()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
         
    }

    public void Init() {
        this.gameM = GameManager.Instant;
        this._HP = 100;
        if(this.gameM == null)
            this.gameM = GameManager.Instant;
        _player = this.gameM.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instant.GameState != GAME_STATE.Play)
            return;
        this.ChasePlayer();
        if (DetectObstacle())
            _player = null;

        Collider2D[] collectHit = Physics2D.OverlapCircleAll(this.transform.position, _detectTargetRadius, _playerLayerMask);
        foreach (Collider2D cl in collectHit)
        {
            if (cl.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
                continue;
            _player = cl.transform;
        }

        if(_player != null)
        {
            if (Vector2.Distance(_player.position, this.transform.position) > _detectTargetRadius)
                _player = null;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instant.GameState != GAME_STATE.Play)
        {
            this._rigi.velocity = Vector2.zero;
            return;
        }
        this._rigi.velocity = this.transform.up * _speed * _movement;
    }

    bool DetectObstacle()
    {
        if (_player == null)
        { 
            return true;
        }

        Vector2 dir = _player.position - this.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, dir.magnitude, _layerMask);
        if (hit.collider == null)
            return false;

        if (hit.collider.CompareTag("Player"))
            return false;

        Debug.DrawLine(this.transform.position, hit.point, Color.red);

        Debug.DrawRay(hit.point, hit.normal,Color.yellow);

        return true; 
    }

    void ChasePlayer()
    {
        if (_player == null)
        {
            _movement = Vector2.zero;
            return;
        }

        Vector2 dir = _player.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;


        Quaternion q = this.transform.rotation;
        q.eulerAngles = new Vector3(0,0,angle);

        this.transform.rotation = q;

        _movement = Vector2.one;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, _detectTargetRadius);
    }

    public void GetHit(float dmg)
    {
        if (this._HP <= 0)
            return;

        if (dmg - _armor > 0)
            this._HP -= (dmg - _armor);

        if (this._HP < 0)
        {
            this.gameObject.SetActive(false);
            this.gameM.kill++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
         
        IGetHit isCanGetHit = collision2D.gameObject.GetComponent<IGetHit>();

        if (isCanGetHit == null)
            return;

        isCanGetHit.GetHit(_baseDmg);
    }

}
