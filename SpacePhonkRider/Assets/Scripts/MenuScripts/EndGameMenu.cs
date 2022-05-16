namespace MenuScripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using HealthControl.HealthControllerType;


    public class EndGameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject endGameMenuUI;
        [SerializeField] private GameObject hero;

        private void FinishGame()
        {
            endGameMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        private void Start()
        {
            endGameMenuUI.SetActive(false);
            hero.GetComponent<HeroHealthController>().OnDie += FinishGame;
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}