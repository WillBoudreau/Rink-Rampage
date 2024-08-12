using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NetTrigger : MonoBehaviour
{
    public TextMeshProUGUI scoreTextHome;
    public TextMeshProUGUI scoreTextAway;
    public AudioSource ScoreSound;
    public int homeScore = 0;
    public int awayScore = 0;
    public PuckBehaviour puck;

    void Start()
    {
        puck = GameObject.Find("Puck").GetComponent<PuckBehaviour>();
        scoreTextHome.text = "Home: " + homeScore.ToString();
        scoreTextAway.text = "Away: " + awayScore.ToString();
        ScoreSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Puck" && this.gameObject.tag == "HomeNet")
        {
            awayScore++;
            scoreTextAway.text = "Away: " + awayScore.ToString();
            Debug.Log(awayScore);
        }
        else if (other.gameObject.tag == "Puck" && this.gameObject.tag == "AwayNet")
        {
            ScoreSound.Play();
            homeScore++;
            puck.ResetPuck();
            scoreTextHome.text = "Home: " + homeScore.ToString();
            Debug.Log(homeScore);
        }
    }
}
