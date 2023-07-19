using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME_STATE {
    Idle,
    Play,
    Over,
    Pause
}

public class GameManager : Singleton<GameManager>
{

    [SerializeField] PlayerController _player;
    public PlayerController player => _player;
    private int _kill = 0;

    public int kill {
        get {
            return _kill;
        }

        set {
            if (value < 0)
                value = 0;

            _kill = value;

            UIManager.Instant.SetUIScore(_kill);
        }
    }

    public GAME_STATE GameState = GAME_STATE.Idle;

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


    public void TestButton() {

        Debug.LogError("Call herre");
    }
}
