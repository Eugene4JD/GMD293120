namespace Score
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    using System;


    public class ScoreManager : MonoBehaviour
    {
        public event Action SpawnBuff = delegate { };

        public event Action DifficultyUpgrade = delegate { };


        [field: SerializeField] public int TimeMultiplier { get; set; }

        [SerializeField] private Text scoreText;

        [SerializeField] private Text highScoreText;

        [SerializeField] private int pointsToBuff = 200;

        [SerializeField] private int procentageOfDifficulty;

        private int InitialBuff;

        private int score;
        private int spaceShipScore;
        private int difficultyScore;
        private int highscore;

        private void Start()
        {
            InitialBuff = pointsToBuff;
            scoreText.text = score + " POINTS";
            highscore = PlayerPrefs.GetInt("highscore", 0);
            highScoreText.text = "HIGHSCORE: " + highscore;
            StartCoroutine(TimePointsRoutine());
        }

        private void AddTimePoint()
        {
            score += TimeMultiplier;
            difficultyScore += TimeMultiplier;
            UpdateScore();
        }

        public void AddEnemyPoints(int enemyPointWeight)
        {
            spaceShipScore += enemyPointWeight;
            difficultyScore += enemyPointWeight;
            if (spaceShipScore > pointsToBuff)
            {
                SpawnBuff();
                spaceShipScore = 0;
            }

            score += enemyPointWeight;
            UpdateScore();
        }


        private void UpdateScore()
        {
            if (difficultyScore > procentageOfDifficulty)
            {
                if (pointsToBuff > (InitialBuff / 100) * 30)
                    pointsToBuff -= InitialBuff / 100;
                DifficultyUpgrade();
            }

            scoreText.text = score + " POINTS";
            UpdateHighScore();
        }

        private void UpdateHighScore()
        {
            if (highscore < score)
            {
                PlayerPrefs.SetInt("highscore", score);
                highscore = PlayerPrefs.GetInt("highscore", 0);
                highScoreText.text = "HIGHSCORE: " + highscore;
            }
        }

        private IEnumerator TimePointsRoutine()
        {
            while (gameObject.activeInHierarchy)
            {
                AddTimePoint();
                yield return new WaitForSeconds(1);
            }
        }
    }
}