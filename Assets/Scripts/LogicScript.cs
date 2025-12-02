using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public static GameManager gameManager;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        if(GameData.Instance == null){
            GameObject dataObj = new GameObject("GameData");
            dataObj.AddComponent<GameData>();
        }  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateScore();
    }
    public void updateScore()
    {

    }
}
