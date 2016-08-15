using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LobyManager : MonoBehaviour {

    public Text playerLevelText;
    public Text playerStatsText;

    public GameObject player;

	void Update () 
    {
        playerLevelText.text = "Niveau : " + PlayerPrefs.GetInt("playerLevel");
        playerStatsText.text = "Attaque = : " + player.GetComponent<PlayerDatas>().atk.ToString() + "\n" + "Defense = : " + player.GetComponent<PlayerDatas>().def.ToString() + "\n"
                + "Attaque speciale = : " + player.GetComponent<PlayerDatas>().speAtk.ToString() + "\n" + "Defense speciale = : " + player.GetComponent<PlayerDatas>().speDef.ToString();
	}
}
