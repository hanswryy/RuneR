using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_Buttons : MonoBehaviour
{
    public GameObject pause_panel, pause_btn;
    public Levels levels;
    public void Retry() {
        levels = GameObject.Find("Levels").GetComponent<Levels>();
        levels.floor = 1;
        levels.add = 2;
        levels.sq = 6;
        levels.hp = 5;
        levels.score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }
    public void Play() {
        SceneManager.LoadScene("GamePlay");
    }
    public void Exit() {
        Application.Quit();
    }
    public void Menu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("Levels"));
    }
    public void Pausee() {
        Time.timeScale = 0;
        pause_panel.gameObject.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().paused = true;
        pause_btn.GetComponent<Image>().enabled = false;
    }
    public void Resume() {
        pause_panel.SetActive(false);
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<Player>().paused = false;
        pause_btn.GetComponent<Image>().enabled = true;
    }
}
