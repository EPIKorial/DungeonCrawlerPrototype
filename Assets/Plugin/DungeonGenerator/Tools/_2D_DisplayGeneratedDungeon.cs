using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DungeonGenerator;

public class _2D_DisplayGeneratedDungeon : MonoBehaviour 
{

    public int roomNbr;
    public int mapSizeX;
    public int mapSizeY;
    public int roomMaxSizeX;
    public int roomMaxSizeY;
    public int roomMinSizeX;
    public int roomMinSizeY;

    public List<string> map;
    public GameObject ground;
    public GameObject wall;
    public GameObject corner;
    public GameObject In;
    public GameObject Out;
    public GameObject torch;
    public GameObject player;

    public GameObject[] monsters;
    private GameObject _go;


	void Start () 
    {
        map = DungeonGen.newMap(roomNbr, mapSizeY, mapSizeX, roomMinSizeY, roomMinSizeX, roomMaxSizeY, roomMaxSizeX);
        displayMap();
	}

    void displayMap()
    {
        for (int i = 0; i < map.Count; i++)
        {
            char[] tmp = map[i].ToCharArray();
            for (int x = 0; x < tmp.Length; x++)
            {
                if (tmp[x] == ' ')
                   Instantiate(ground, new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
                if (tmp[x] == '-' || tmp[x] == '|')
                    Instantiate(wall, new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
                if (tmp[x] == '#' || tmp[x] == 'X')
                    Instantiate(corner, new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
                if (tmp[x] == 'E')
                {
                    Instantiate(In, new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
                    player = (GameObject)Instantiate(player, new Vector3(x, i-1, 0), new Quaternion(0, 0, 0, 0));
                    player.GetComponent<_2D_PlayerTileByTileMovement>().pos = new Vector2(x, i-1);
                    Instantiate(torch, new Vector3(x+1, i, 0), new Quaternion(0, 0, 0, 0));
                    Instantiate(torch, new Vector3(x-1, i, 0), new Quaternion(0, 0, 0, 0));
                    Instantiate(ground, new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
                }
                if (tmp[x] == 'S')
                {
                    Instantiate(Out, new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
                    Instantiate(ground, new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
                }
            }
        }
        AddMonsters();
    }

    void AddMonsters()
    {
        for (int i = 0; i < map.Count; i++)
        {
            char[] tmp = map[i].ToCharArray();
            for (int x = 0; x < tmp.Length; x++)
            {
                if (map[i][x] == ' '
                    && map[i][x+1] == ' '
                    && map[i][x-1] == ' '
                    && map[i+1][x] == ' '
                    && map[i-1][x] == ' ' && Random.Range(0, 100) >= 96)
                    _go = (GameObject)Instantiate(monsters[(int)Random.Range(0, monsters.Length)], new Vector3(x, i, 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
