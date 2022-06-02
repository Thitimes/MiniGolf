using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    public BallController ball;
    public TextMeshProUGUI labelPlayerName;

    private PlayerRecord playerRecord;
    private int playerIndex;
    private void Start()
    {
        playerRecord = GameObject.Find("PlayerRecord").GetComponent<PlayerRecord>();
        playerIndex = 0;
        SetUpPlayer();
    }
    private void SetUpPlayer()
    {
        ball.SetUpBall(playerRecord.playerColours[playerIndex]);
        labelPlayerName.text = playerRecord.playerList[playerIndex].name;
    }
    public void NextPlayer(int previousPutts)
    {
        playerRecord.AddPutts(playerIndex, previousPutts);
        if (playerIndex < playerRecord.playerList.Count - 1)
        {
            playerIndex++;

            SetUpPlayer();
        }
        else
        {
            if(playerRecord.levelIndex == playerRecord.level.Length - 1)
            {
                //load the score board

            }
            else
            {
                playerRecord.levelIndex++;
                SceneManager.LoadScene(playerRecord.level[playerRecord.levelIndex]);
            }
        }
    }
}
