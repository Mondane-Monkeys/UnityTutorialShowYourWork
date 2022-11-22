using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int highscore;
    public string playername;
    public string currentName = "player";
    public string test;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
            currentName = "player";
            test = Application.persistentDataPath+"/savefile.json";
        }
        else
        {
            Destroy(gameObject);
        }


        //if playername is saved, get that
        //get highschores
        
    }

    //handle save/load
    //store playername
    //startGame
    //return to menu
    
    
    /////////////////////
    //////SaveLoad///////
    /////////////////////
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highestScore;
    }

    public void Save(int score)
    {
        if (highscore<score)
        {
            SaveData data = new SaveData();
            data.playerName = currentName;
            data.highestScore = score;
            highscore = score;
            playername = currentName;
            
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    }

    public void Load()
    {
        string filePath = Application.persistentDataPath+"/savefile.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playername = data.playerName;
            highscore = data.highestScore;
        }
    }
}
