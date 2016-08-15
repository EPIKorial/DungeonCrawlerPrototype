using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackController : MonoBehaviour {

    public struct Target
    {
        public Image targetImage;
        public Text targetName;
    };

    private GameObject canvas;
    private GameObject targetGui;

    private GameObject targetGo;
    private Target target;

	void Start () {
        canvas = GameObject.Find("Canvas");
        targetGui = GameObject.Find("TargetGui");
        target.targetImage = targetGui.transform.FindChild("Image").GetComponent<Image>();
        target.targetName = targetGui.transform.FindChild("Text").GetComponent<Text>();
        targetGui.transform.FindChild("Panel").gameObject.SetActive(false);
        targetGui.transform.FindChild("Panel").gameObject.SetActive(false);
	}
	
	void Update () 
    {
	    if (targetGo)
        {
            targetGui.transform.FindChild("Panel").gameObject.SetActive(true);
            targetGui.transform.FindChild("Image").gameObject.SetActive(true);
            target.targetImage.sprite = targetGo.GetComponent<SpriteRenderer>().sprite;
            target.targetName.text = (string)(targetGo.name.Replace("(Clone)", ""));
        }
        else
        {
            target.targetName.text = "";
            targetGui.transform.FindChild("Panel").gameObject.SetActive(false);
            targetGui.transform.FindChild("Image").gameObject.SetActive(false);
        }

        
        /// On Click
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitPoint = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hitPoint && hitPoint.transform.tag == "Enemy")
                targetGo = hitPoint.transform.gameObject;
            else if (!hitPoint)
                targetGo = null;
        }
	}
}
