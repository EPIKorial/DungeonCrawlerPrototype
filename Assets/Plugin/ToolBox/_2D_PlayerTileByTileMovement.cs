using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _2D_PlayerTileByTileMovement : MonoBehaviour {

    enum direction
    {
        R,
        L
    };

	private Rigidbody2D _rig;
    public Vector2 pos;
    public List<string> map;
    private Transform myTransform;

    public char[] freeChars;
    private direction dir;
    public float speed;
    private GameObject canvas;

	void Start()
	{
        dir = direction.R;
		_rig = this.GetComponent<Rigidbody2D> ();
        myTransform = GetComponent<Transform>();
        string tmp = "E ";
        freeChars = tmp.ToCharArray();
        map = GameObject.Find("DungeonGenDisp").GetComponent<_2D_DisplayGeneratedDungeon>().map;
        canvas = GameObject.Find("Canvas");
	}

    void Update()
    {
        myTransform.position = Vector3.Lerp(myTransform.position, new Vector3(pos.x, pos.y, 0), speed);
    }

    public bool tileIsFree(int y, int x)
    {
        char[] tmp = map[x].ToCharArray();
        for (int i = 0; i < freeChars.Length;i++)
        {
            if (tmp[y] == freeChars[i])
                return true;
            if (tmp[y] == 'S')
                StartCoroutine(GoingDeeper());
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
        {
            pos = new Vector2(pos.x + 1, pos.y);
            if (dir == direction.L)
            {
                dir = direction.R;
                myTransform.FindChild("5_0").GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    public void MoveLeft()
    {
        if (tileIsFree((int)(pos.x - 1), (int)pos.y))
        {
            pos = new Vector2(pos.x - 1, pos.y);
            if (dir == direction.R)
            {
                dir = direction.L;
                myTransform.FindChild("5_0").GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    IEnumerator GoingDeeper()
    {
        canvas.GetComponent<GuiHandler>().up.gameObject.SetActive(false);
        canvas.GetComponent<GuiHandler>().down.gameObject.SetActive(false);
        canvas.GetComponent<GuiHandler>().right.gameObject.SetActive(false);
        canvas.GetComponent<GuiHandler>().left.gameObject.SetActive(false);
        GameObject.Find("PlayerCamera").GetComponent<Animator>().SetTrigger("Transition");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
