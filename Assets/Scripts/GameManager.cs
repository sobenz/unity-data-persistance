using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string currentPlayerName;
    private HighScoreData highScoreData = new HighScoreData();
    private string highScorePath;

    public void LoadHighScores()
    {
        if (File.Exists(highScorePath))
        {
            highScoreData =  JsonUtility.FromJson<HighScoreData>(File.ReadAllText(highScorePath));
        }
        
    }

    public void SaveHighScores()
    {
        var data = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(highScorePath, data);
    }

    public void RecordCurrentPlayerScore(int score)
    {
        if (score > highScoreData.Score)
        {
            highScoreData.Score = score;
            highScoreData.PlayerName = currentPlayerName;
        }
    }

    public void SetCurrentPlayerName(string name)
    {
        currentPlayerName = name;
    }
    public string CurrentPlayer => currentPlayerName;
    public HighScoreData HighScore => highScoreData;

    private void Awake()
    {
        highScorePath = Path.Combine(Application.persistentDataPath, "highScores.json");
        LoadHighScores();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class HighScoreData
    {
        public int Score;
        public string PlayerName;
    }
}
