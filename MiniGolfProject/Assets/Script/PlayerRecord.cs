using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public List<Player> GetScoreboardList()
    {
        foreach(var player in playerList)
        {
            foreach(var puttscore in player.putts)
            {
                player.totalPutts += puttscore;
            }
        }
       return (from p in playerList orderby p.totalPutts select p).ToList();
        
    }
    public void AddPutts(int playerIndex,int PuttsCount)
    {
        playerList[playerIndex].putts[levelIndex] = PuttsCount;
    }
    public class Player
    {
        public int totalPutts;
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
