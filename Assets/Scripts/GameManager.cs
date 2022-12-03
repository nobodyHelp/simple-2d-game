using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private Text timerText;
    private float timerStart = 0;

    private bool _gameIsOver = false;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        if (_gameIsOver == false)
        {
            timerStart += Time.deltaTime;
        }        
    }

    private void AllEnemiesDie()
    {
        gameOverScreen.SetActive(true);
        timerText.text = "You have destroyed all the enemies in " + Mathf.Round(timerStart).ToString() + " seconds.";
        timerStart = 0;
        _gameIsOver = true;
    }

    private void HeroDie()
    {
        gameOverScreen.SetActive(true);
        timerText.text = "You're die in " + Mathf.Round(timerStart).ToString() + " seconds.";
        timerStart = 0;
        _gameIsOver = true;
    }

    private void OnEnable()
    {
        EventManager.OnHeroDie += HeroDie;
        EventManager.GameOver += AllEnemiesDie;
    }

    private void OnDisable()
    {
        EventManager.OnHeroDie -= HeroDie;
        EventManager.GameOver -= AllEnemiesDie;
    }
}
