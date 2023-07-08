using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instant;
    public static GameManager Instant => _instant;

    [SerializeField] PlayerController _player;
    public int _kill = 0;

    private void Awake()
    {
        _instant = this;
    }

    void Init() {
        _player.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
