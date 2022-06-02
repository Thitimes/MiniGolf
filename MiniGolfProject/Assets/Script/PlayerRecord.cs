using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    public List<Player> playerList;
    public string[] level;
    public Color[] playerColours;
    public int levelIndex;

    private void OnEnable()
    {
        playerList = new List<Player>();
        DontDestroyOnLoad(gameObject);
    }

    public void AddPlayer(string name)
    {
        playerList.Add(new Player(name, playerColours[playerList.Count],level.Length));
        
    }
    public void AddPutts(int playerIndex,int PuttsCount)
    {
        playerList[playerIndex].putts[levelIndex] = PuttsCount;
    }
    public class Player
    {
        public string name;
        public Color color;
        public int[] putts;    

        public Player (string newname, Color newColor,int levelCount)
        {
            name = newname;
            color = newColor;
            putts = new int[levelCount];
        }
    }
}
