using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class UIManager : Singleton<UIManager>
{ 

    [SerializeField] Slider _playerHealthBar;
    [SerializeField] Button _restartGameBtn;
    [SerializeField] Text _nameBtn, _scoreText;
    [SerializeField]
    InputField _inputField;
    [SerializeField] ScrollRect ScrollRect;

    string _playerName = "";

    [SerializeField]
    UnityAction<int, int> H;

    [SerializeField]
    UnityEvent<int,int> U;

    Action<int,int> A;

    Predicate<int> B;

    Func<int, int, float> C;
    [SerializeField]
    [Range(0, 1)] float testScroll;

    [SerializeField]
    int testIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        _restartGameBtn.onClick.AddListener(ClickPlayGame);


        A += calSum;
        A += callDiff;

        U.AddListener(callDiff);

        U.AddListener(calSum);

        _nameBtn.text = "";

        _scoreText.text = $"kil is {100:00#} ";

        _inputField.onValueChanged.AddListener((val) => {
            Debug.LogError(val);
        });


       
    }

    public void calTest(int a) {
    }

    public void calSum(int a, int b) {

        Debug.LogError(a + b);
    }

    public void callDiff(int a, int b)
    {

        Debug.LogError(a - b);
    }

    public void SetUIScore(int score) {
        _scoreText.text = string.Format("{0}: {1:00#}",_playerName, score);
    }

    // Update is called once per frame
    void Update()
    {
        ScrollRect.horizontalNormalizedPosition = (float)testIndex / ScrollRect.content.transform.childCount;
    }

    public void setPlayerHealthBar(float value) {
        _playerHealthBar.value = value;
        if (value == 0)
            _restartGameBtn.gameObject.SetActive(true);
    }

    public void ClickRestartBtn() {
        SceneManager.LoadScene(0);
    }


    public void ClickPlayGame() {
        GameManager.Instant.GameState = GAME_STATE.Play;

        _playerName = _inputField.text;
        _scoreText.text = $"{_playerName}: {0:00#} ";

        EnemyManager.Instant.Init();
        _restartGameBtn.gameObject.SetActive(false);

        _restartGameBtn.onClick.RemoveAllListeners();
        _restartGameBtn.onClick.AddListener(ClickRestartBtn);
    }

    public void PauseGame() {
        if (GameManager.Instant.GameState != GAME_STATE.Play && GameManager.Instant.GameState != GAME_STATE.Pause)
            return;


        if (GameManager.Instant.GameState == GAME_STATE.Play)
            GameManager.Instant.GameState = GAME_STATE.Pause;
        else
            GameManager.Instant.GameState = GAME_STATE.Play;
    }
}
