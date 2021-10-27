using UnityEngine;
using UnityEngine.SceneManagement;


public class _ButtonsMenuScript : MonoBehaviour
{
 
    public void OnBtn_Play()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBtn_Upgrades()
    {
     
        SceneManager.LoadScene(3);
    }
    public void OnBtn_Shop()
    {
      
        SceneManager.LoadScene(5);
    }
    public void OnBtn_Stats()
    {
      
        SceneManager.LoadScene(4);
    }
    public void OnBtn_Exit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
