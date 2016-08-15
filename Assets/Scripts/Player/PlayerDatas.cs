using UnityEngine;
using System.Collections;

public class PlayerDatas : MonoBehaviour {

    public int level;

    /// <summary>
    /// Stats
    /// </summary>
    public int pv;
    public float atk;
    public float def;
    public float speAtk;
    public float speDef;

    /// <summary>
    /// Stuff
    /// </summary>
    public GameObject[] stuff;


	void Start () 
    {
        level = PlayerPrefs.GetInt("playerLevel");
        pv = 100 + (100 / 10 * level);
        atk = 1 + (level / 10) + getAtkFromStuff();
        def = 1 + (level / 10) + getDefFromStuff();
        speAtk = 1 + (level / 10) + getSpeAtkFromStuff();
        speDef = 1 + (level / 10) + getSpeDefFromStuff();
	}

    public float getAtkFromStuff()
    {
        return 0;
    }

    public float getDefFromStuff()
    {
        return 0;
    }

    public float getSpeAtkFromStuff()
    {
        return 0;
    }

    public float getSpeDefFromStuff()
    {
        return 0;
    }

    public void PlayerLevelUp()
    {
        ++level;
        PlayerPrefs.SetInt("playerLevel", level);
        PlayerPrefs.Save();
    }

    public void PlayerDeath()
    {
        level = 1;
        PlayerPrefs.SetInt("playerLevel", 1);
        PlayerPrefs.Save();
    }
	
	void Update () 
    {
	
	}
}
