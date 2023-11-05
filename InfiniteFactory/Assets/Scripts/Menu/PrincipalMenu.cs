using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincipalMenu : MonoBehaviour
{
    [SerializeField] private GameObject Buttons;
    [SerializeField] private GameObject howToPlayMenu;

    private void Awake()
    {
        howToPlayMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void HowToPlay()
    {
        Buttons.SetActive(false);
        howToPlayMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        Buttons.SetActive(true);
        howToPlayMenu.SetActive(false);
    }
}
