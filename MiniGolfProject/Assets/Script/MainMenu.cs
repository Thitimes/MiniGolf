using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputName;
    public PlayerRecord playerRecord;
    public Button buttonStart;
    public Button buttonAddPlayer;
    public void ButtonAddPlayer()
    {
        playerRecord.AddPlayer(inputName.text);
        buttonStart.interactable = true;
        inputName.text = "";
        if(playerRecord.playerList.Count == playerRecord.playerColours.Length)
        {
            buttonAddPlayer.interactable = false;
        }
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(playerRecord.level[0]);
    }
}
