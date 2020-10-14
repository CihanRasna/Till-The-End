using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private Text distanceText;
    public static float distance;
    private int roundedDistance = 0;
   
    
    void Start()
    {
        distanceText = GameObject.Find("RangeText").GetComponent<Text>();
        player = GameObject.Find("Player");
        distanceText.text = roundedDistance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        distance =  Mathf.Round(Vector3.Distance(player.transform.position, this.transform.position) * 100.0f) * 0.01f;
        roundedDistance = (int) distance;
        distanceText.text = roundedDistance + " M";
    }
}
