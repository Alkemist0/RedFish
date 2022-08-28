using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int aliveFish;

    public GameObject LoseScreen;
    public GameObject WinScreen;

    public TextMeshProUGUI WinText;

    private void Awake()
    {
        aliveFish = 14;
    }

    public void ChangeScene(int id)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(id);
    }

    public void Lose()
    {
        LoseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        WinText.text = "You finished with " + aliveFish + " Blue Fish!";
        WinScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
