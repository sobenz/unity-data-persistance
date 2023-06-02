using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField currentNameInput;

    private void Start()
    {
        if(GameManager.Instance != null)
            currentNameInput.text = GameManager.Instance.CurrentPlayer;
    }

    private void Update()
    {
        if (GameManager.Instance != null)
            highScoreText.text = $"Best Score : {GameManager.Instance.HighScore.PlayerName} : {GameManager.Instance.HighScore.Score}";
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void OnExitGame()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.SaveHighScores();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnCurrentNameChange(string name)
    {
        GameManager.Instance.SetCurrentPlayerName(name);
    }
}
