using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject startButton;

    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI highScore;

    public static float distance;
    private float panelWaitTime = 0f;
    private float gameStartWait = 0f;

    [SerializeField] private int roundedDistance = 0;

    void Start()

    {
        player = GameObject.Find("Player");
        startButton = GameObject.Find("StartButton");
        
        distanceText = GameObject.Find("RangeText").GetComponent<TextMeshProUGUI>();
        distanceText.text = roundedDistance.ToString();
        
        startButton.SetActive(false);
        panel.SetActive(false);
        
        highScore.text = PlayerPrefs.GetInt("HighScore" , 0) + " M";
    }

    void Update()
    {
        if (gameStartWait <= 3f)
        {
            gameStartWait += Time.deltaTime;
            if (gameStartWait >= 3f)
            {
                startButton.SetActive(true);
                return;
            }
        }

        distance = Mathf.Round(Vector3.Distance(player.transform.position, this.transform.position) * 100.0f) * 0.01f;
        roundedDistance = (int) distance;
        distanceText.text = roundedDistance + " M";

        if (PlayerManager.isGameLose)
        {
            
            if (roundedDistance > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore" , roundedDistance);
                highScore.text = PlayerPrefs.GetInt("HighScore") + " M";
            }
            
            // highScore.text = PlayerPrefs.GetInt("HighScore" , roundedDistance) + "M";
            panelWaitTime += Time.deltaTime;
            if (panelWaitTime >= 2)
            {
                panel.SetActive(true);
                panelWaitTime = 2;
            }
        }
        
        else
        {
            panel.SetActive(false);
        }
    }

    public void StartGame()
    {
        PlayerManager.speed = 4f;
        PlayerManager.isGameStarted = true;
        startButton.SetActive(false);
    }
    
    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerManager.isGameLose = false;
        PlayerManager.isGameStarted = false;
    }
}