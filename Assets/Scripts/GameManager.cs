using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject player;
    
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI finalScore;
    
    public static float distance;
    
    [SerializeField] private int roundedDistance = 0;

    void Start()
    {
        panel.SetActive(false);
        distanceText = GameObject.Find("RangeText").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");
        distanceText.text = roundedDistance.ToString();
    }
    
    void Update()
    {
        distance = Mathf.Round(Vector3.Distance(player.transform.position, this.transform.position) * 100.0f) * 0.01f;
        roundedDistance = (int) distance;
        distanceText.text = roundedDistance + " M";

        if (Movement.GameLose)
        {
            panel.SetActive(true);
            finalScore.text = distanceText.text;
        }
        else
        {
            panel.SetActive(false);
        }
    }
    
    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Movement.GameLose = false;
    }
}