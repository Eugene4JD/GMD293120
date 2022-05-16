namespace MenuScripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using CustomInput;


    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;

        [SerializeField] private GameObject PauseMenuUi;

        [SerializeField] private GameObject HeroObject;

        private void Start()
        {
            PauseMenuUi.SetActive(false);
            HeroObject.GetComponent<PlayerInput>().OnPause += HandlePause;
        }

        private void Awake()
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        private void HandlePause()
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        public void Resume()
        {
            PauseMenuUi.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        private void Pause()
        {
            PauseMenuUi.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}