using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyBasicAI : MonoBehaviour {

    enum Direction
    {
        up,
        down,
        right,
        left
    };

    private Direction dir;
    public Vector2 pos;
    private List<string> map;
    private Transform myTransform;
    public char[] freeChars;
    private Dictionary<int, string> mov;
    private float nextMove;
    public Texture attackSprite;

	// Use this for initialization
	void Start () {
        mov = new Dictionary<int, string>();
        mov.Add(1, "MoveUp");
        mov.Add(2, "MoveDown");
        mov.Add(3, "MoveLeft");
        mov.Add(4, "MoveRight");
        dir = Direction.up;
        myTransform = GetComponent<Transform>();
        map = GameObject.Find("DungeonGenDisp").GetComponent<_2D_DisplayGeneratedDungeon>().map;
        string tmp = "E ";
        freeChars = tmp.ToCharArray();
        pos = myTransform.position;
	}
	

	void Update () {
	    if (nextMove < Time.time)
        {
            nextMove = Time.time + 1;
            Invoke(mov[(int)Random.Range(1, 5)], 0);
        }
        myTransform.position = Vector3.Lerp(myTransform.position, new Vector3(pos.x, pos.y, 0), 0.1f);
	}

    public bool tileIsFree(int y, int x)
    {
        char[] tmp = map[x].ToCharArray();
        for (int i = 0; i < freeChars.Length; i++)
        {
            if (tmp[y] == freeChars[i])
                return true;
        }
        return false;
    }

    public void MoveUp()
    {
        if (tileIsFree((int)pos.x, (int)(pos.y + 1)))
            pos = new Vector2(pos.x, pos.y + 1);
    }

    public void MoveDown()
    {
        if (tileIsFree((int)pos.x, (int)(pos.y - 1)))
            pos = new Vector2(pos.x, pos.y - 1);
    }

    public void MoveRight()
    {
        if (tileIsFree((int)(pos.x + 1), (int)pos.y))
            pos = new Vector2(pos.x + 1, pos.y);
    }

    public void MoveLeft()
    {
        if (tileIsFree((int)(pos.x - 1), (int)pos.y))
            pos = new Vector2(pos.x - 1, pos.y);
    }
}
