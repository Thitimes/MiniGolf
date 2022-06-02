using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public BallController ball;
    private PlayerRecord playerRecord;
    private void Start()
    {
        playerRecord = GameObject.Find("PlayerRecord").GetComponent<PlayerRecord>();
          
    }
    private void SetUpPlayer()
    {

    }
}
