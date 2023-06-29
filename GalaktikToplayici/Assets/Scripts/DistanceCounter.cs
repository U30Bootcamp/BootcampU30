using System.IO;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private IntegerScriptableObject distance;
    [SerializeField] private IntegerScriptableObject highScore;
    [SerializeField] private Transform checkpoint;

    private string _dataPath;
    private int _prevHighScore;
    private class SaveObj
    {
        public int highScore;
    }
    
    private void Awake()
    {
        _dataPath = Application.dataPath + "/save.txt";
        _prevHighScore = 0;
        
        if (File.Exists(_dataPath))
        {
            string savedString = File.ReadAllText(_dataPath);
            SaveObj temp = JsonUtility.FromJson<SaveObj>(savedString);
            highScore.SetInt(temp.highScore);
            _prevHighScore = temp.highScore;
        }

        // checkpoint = transform;
    }

    private void Update()
    {
        distance.SetInt(Mathf.FloorToInt((checkpoint.position - transform.position).magnitude));
    }
    
    public void GameOverEvent()
    {
        SaveObj temp = new SaveObj
        {
            highScore = distance.number
        };

        if (temp.highScore > _prevHighScore)
        {
            string json = JsonUtility.ToJson(temp);
            File.WriteAllText(_dataPath, json);
        }
    }
 
}
