using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] List<BulletBase> _listBullets = new List<BulletBase>();
    [SerializeField] GunController _currentGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            _currentGun.ChangeBullet(_listBullets[0]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentGun.ChangeBullet(_listBullets[1]);
        }
    }
}
