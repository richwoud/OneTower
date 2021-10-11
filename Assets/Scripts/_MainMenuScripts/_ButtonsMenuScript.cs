using UnityEngine;
using UnityEngine.SceneManagement;


public class _ButtonsMenuScript : MonoBehaviour
{
    public void OnBtn_Play()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBtn_Shop()
    {
        SceneManager.LoadScene(3);
    }
    
}
