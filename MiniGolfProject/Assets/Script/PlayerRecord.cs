using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    public List<Player> playerList;
    public string[] level;
    public Color[] playerColours;


    public class Player
    {
        public string name;
        public Color color;
        int[] putts;

        public Player (string newname, Color newColor,int levelCount)
        {
            name = newname;
            color = newColor;
            putts = new int[levelCount];
        }
    }
}
