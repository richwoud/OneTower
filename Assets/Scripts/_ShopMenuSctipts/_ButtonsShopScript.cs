using UnityEngine;
using UnityEngine.SceneManagement;

public class _ButtonsShopScript : MonoBehaviour
{
    public void OnBtn_Exit()
    {
        SceneManager.LoadScene(0);
    }
}
