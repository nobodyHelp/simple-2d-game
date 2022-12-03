using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float timeStart = 0;
    public Text timerText;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        timeStart += Time.deltaTime;
    }       
}
