using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IGetHit
{
    float _HP = 100;
    float _armor = 10;

    Rigidbody2D _rigi;
    [SerializeField] float _speed, _speedRotate, _coolDownTime;
    Vector2 _movement;

    [SerializeField] GameObject _bullet;
    [SerializeField] GunControllerBase _gun;

  
    // Start is called before the first frame update
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    public void Init() {
        if (_gun == null)
            this._gun = this.GetComponentInChildren<GunControllerBase>();
        _gun.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
       // this.Moving();
        this.RotatePlayer();

        if (Input.GetKeyDown(KeyCode.Space)) {
            _gun.Fire();
        }
    }
    //test git
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
            this._rigi.velocity = this.transform.right * _speed;
        else if (Input.GetAxisRaw("Vertical") < 0)
            this._rigi.velocity = this.transform.right * -_speed;
        else
            this._rigi.velocity = Vector2.zero;
    }

    //Nâng cao hơn 1 chút
    void RotatePlayer()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if (inputX > 0)
            this.transform.Rotate(new Vector3(0,0, _speedRotate * Time.deltaTime));
        else if (inputX < 0)
        {
            this.transform.Rotate(new Vector3(0, 0, -_speedRotate * Time.deltaTime));
        }
    }

    //Căn bản
    void Moving()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        
    }

    public void GetHit(float dmg) {
        if(dmg - _armor > 0)
            this._HP -= (dmg - _armor);

        if (this._HP < 0)
            SceneManager.LoadScene(0);
    }

   
}
