using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;

    public float difficulty;
    public GameObject goldText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }

        LoadData();
        goldText = GameObject.Find("GoldText");
        goldText.GetComponent<Text>().text = "Gold: " + gold;


    }
    public void _GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void _LevelOne()
    {
        difficulty = 10f;
    }

    public void _LevelTwo()
    {
        difficulty = 2f;
    }

    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public float fireRate;
        public int gold;
    }

        public string playerName;
        public int gold;
        public float fireRate;

    public void SaveData(){
        PlayerData data = new PlayerData();
        data.playerName = playerName;
        data.fireRate = fireRate;
        data.gold = gold;

        string path = Application.dataPath + "/playerData.json";
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(path,jsonData);
    }

    public void LoadData(){
        string path = Application.dataPath + "/playerData.json";
        string jsonData = File.ReadAllText(path);

        PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);

        playerName = data.playerName;
        fireRate = data.fireRate;
        gold = data.gold;
    }

    public void SpeedUpButton(){
         if(gold >= 20){
            LoadData();
            fireRate *= 0.9f;
            gold -= 20;
            SaveData();
            Debug.Log("FireRate Increased");
            goldText.GetComponent<Text>().text = "Gold: " + gold;
        } else{
            Debug.Log("Gold is not Enough");
        }
        
    }

    // private void OnApplicationQuit() {
    //     GameManager.Instance.SaveData();
    // }
}
