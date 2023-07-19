using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class UIManager : Singleton<UIManager>
{ 

    [SerializeField] Image _playerHealthBar;
    [SerializeField] Button _restartGameBtn;
    [SerializeField] Text _nameBtn, _scoreText;

    [SerializeField]
    UnityAction<int, int> H;

    [SerializeField]
    UnityEvent<int,int> U;

    Action<int,int> A;

    Predicate<int> B;

    Func<int, int, float> C;

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
        _scoreText.text = string.Format("{0:00#}", 100);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void setPlayerHealthBar(float value) {
        _playerHealthBar.fillAmount = value;
        if (value == 0)
            _restartGameBtn.gameObject.SetActive(true);
    }

    public void ClickRestartBtn() {
        SceneManager.LoadScene(0);
    }


    public void ClickPlayGame() {
        GameManager.Instant.GameState = GAME_STATE.Play;

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
