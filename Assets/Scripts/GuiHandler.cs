using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour {

    public GameObject player;

    public Button up;
    public Button down;
    public Button right;
    public Button left;

    public Button inventory;
	
	void Update () {
        if (GameObject.Find("Player(Clone)") && !player)
        {
            player = GameObject.Find("Player(Clone)");
            up.onClick.AddListener(delegate { player.GetComponent<_2D_PlayerTileByTileMovement>().MoveUp(); });
            down.onClick.AddListener(delegate { player.GetComponent<_2D_PlayerTileByTileMovement>().MoveDown(); });
            right.onClick.AddListener(delegate { player.GetComponent<_2D_PlayerTileByTileMovement>().MoveRight(); });
            left.onClick.AddListener(delegate { player.GetComponent<_2D_PlayerTileByTileMovement>().MoveLeft(); });
            inventory.onClick.AddListener(delegate { player.GetComponent<PlayerInventory>().InventoryButton(); });
        }
	}
}
