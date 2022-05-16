namespace MenuScripts
{
    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

    public class MainMenu : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI highscore;

        private void Awake()
        {
            ShowHighScore();
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void ShowHighScore()
        {
            highscore.text = "Your current highscore is: " + PlayerPrefs.GetInt("highscore", 0);
        }
    }
}