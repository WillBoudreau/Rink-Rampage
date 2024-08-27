using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableSettings : MasterSettings
{
    //Player and AI values
    //Player
    [Header("Player Values")]
    [SerializeField]  public float PlayerSpeed = 10f;
    [SerializeField]  public float PlayerGravity = -9.81f;
    [SerializeField]  public float PlayerMinDistPuck = 2f;
    //AI
    [Header("AI Values")]
    [SerializeField]  public float AISpeed = 10f;
    [SerializeField]  public float AIGravity = -9.81f;
    [SerializeField]  public float AIMinDistPuck = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
