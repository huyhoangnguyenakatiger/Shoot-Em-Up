using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] SceneReference nextLevelScene;
        [SerializeField] GameObject gameOverUI;
        [SerializeField] GameObject gameWinningUI;

        public static GameManager Instance { get; private set; }
        public Player Player => player;

        Player player;
        Boss boss;
        int score;
        float restartTimer = 3f;

        // public bool IsGameOver() => player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0 || boss.GetHealthNormalized() <= 0;
        public bool IsGameOver() => player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0;

        public bool IsGameWinning() => boss.GetHealthNormalized() <= 0 && player.GetHealthNormalized() > 0 && player.GetFuelNormalized() > 0;

        void Awake()
        {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }

        void Update()
        {
            if (IsGameOver())
            {
                restartTimer -= Time.deltaTime;

                if (gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                }

                if (restartTimer <= 0)
                {
                    Loader.Load(mainMenuScene);
                }
            }

            if (IsGameWinning())
            {
                restartTimer -= Time.deltaTime;

                if (gameWinningUI.activeSelf == false)
                {
                    gameWinningUI.SetActive(true);
                }

                if (restartTimer <= 0)
                {
                    var currentScene = SceneManager.GetActiveScene().buildIndex;
                    var nextScene = currentScene++;
                    if (nextScene > SceneManager.sceneCountInBuildSettings)
                    {
                        Loader.Load(mainMenuScene);
                    }
                    else
                    {
                        Loader.Load(nextLevelScene);
                    }
                }
            }
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}