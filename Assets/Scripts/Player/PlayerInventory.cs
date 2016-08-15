using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public GameObject player;
    private GameObject canvas;
    private bool inventoryCheck;
    public GameObject playerInventoryPanel;

    public GameObject lvl;
    public GameObject stats;

	void Start () 
    {
        player = GameObject.Find("Player(Clone)");
        canvas = GameObject.Find("Canvas");
        playerInventoryPanel = GameObject.Find("PlayerInventoryPanel");
        playerInventoryPanel.gameObject.SetActive(false);
        inventoryCheck = false;
	}

    void Update()
    {
        if (!lvl)
            lvl = GameObject.Find("PlayerLevel");
        if (!stats)
            stats = GameObject.Find("PlayerStats");
        if (lvl)
          lvl.GetComponent<Text>().text = "Niveau : " + player.GetComponent<PlayerDatas>().level.ToString();
        if (stats)
            stats.GetComponent<Text>().text = "Attaque = : " + player.GetComponent<PlayerDatas>().atk.ToString() + "\n" + "Defense = : " + player.GetComponent<PlayerDatas>().def.ToString() + "\n"
                + "Attaque speciale = : " + player.GetComponent<PlayerDatas>().speAtk.ToString() + "\n" + "Defense speciale = : " + player.GetComponent<PlayerDatas>().speDef.ToString();
    }

    public void InventoryButton()
    {
        if (inventoryCheck)
        {
            canvas.GetComponent<GuiHandler>().up.gameObject.SetActive(true);
            canvas.GetComponent<GuiHandler>().down.gameObject.SetActive(true);
            canvas.GetComponent<GuiHandler>().right.gameObject.SetActive(true);
            canvas.GetComponent<GuiHandler>().left.gameObject.SetActive(true);
            inventoryCheck = false;
            playerInventoryPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            canvas.GetComponent<GuiHandler>().up.gameObject.SetActive(false);
            canvas.GetComponent<GuiHandler>().down.gameObject.SetActive(false);
            canvas.GetComponent<GuiHandler>().right.gameObject.SetActive(false);
            canvas.GetComponent<GuiHandler>().left.gameObject.SetActive(false);
            inventoryCheck = true;
            playerInventoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
