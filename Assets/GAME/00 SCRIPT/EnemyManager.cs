using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _maxTimeSpawn,_minTimeSpawn;
    float _timer = 0;

    [SerializeField] EnemyController _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer > 0) {
            _timer -= Time.deltaTime;
            return;
        }
        Collider2D[] collider2Ds;
        Vector2 pos;
        do {

            pos = _player.transform.position;
            pos.x += Random.Range(-5f, 5f);
            pos.y += Random.Range(-5f, 5f);

            collider2Ds = Physics2D.OverlapCircleAll(pos, 0.25f);
        } while ( collider2Ds.Length > 0);


        EnemyController e = ObjectPooling.Instant.Getcomp(_enemyPrefab);
        e.transform.position = pos;
        e.gameObject.SetActive(true);

        _timer = Random.Range(_minTimeSpawn, _maxTimeSpawn);
    }
}
