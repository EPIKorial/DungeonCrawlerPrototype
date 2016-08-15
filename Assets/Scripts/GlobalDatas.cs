using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class GlobalDatas : MonoBehaviour {


	public void ChangeScene(int id)
	{
        SceneManager.LoadScene(id);
	}

	public void Quit()
	{
		Application.Quit();
	}

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            GameObject.Find("Canvas").GetComponent<GuiHandler>().up.gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<GuiHandler>().down.gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<GuiHandler>().right.gameObject.SetActive(false);
            GameObject.Find("Canvas").GetComponent<GuiHandler>().left.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<GuiHandler>().up.gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<GuiHandler>().down.gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<GuiHandler>().right.gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<GuiHandler>().left.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
    }

}
