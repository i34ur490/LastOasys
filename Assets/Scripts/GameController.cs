using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverUI;  // UI que exibe a mensagem de "aperte qualquer coisa para reiniciar"

    void Start()
    {
        gameOverUI.SetActive(false);  // Esconde a mensagem de game over no início
    }

    public void GameOver()
    {
        Time.timeScale = 0f;  // Pausa o jogo
        gameOverUI.SetActive(true);  // Exibe a mensagem de game over
    }

    void Update()
    {
        // Se o jogo está pausado, verifica se o jogador aperta uma tecla para reiniciar
        if (Time.timeScale == 0 && Input.anyKeyDown)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;  // Despausa o jogo
        gameOverUI.SetActive(false);  // Esconde a mensagem de game over
        // Reinicia o nível
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
