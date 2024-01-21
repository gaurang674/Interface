using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public int difficulty;
    private gameManager gameManager;
    private Button DifficultyButton;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        DifficultyButton = GetComponent<Button>();
        DifficultyButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(DifficultyButton.gameObject.name + " was clicked.");
        gameManager.StartGame(difficulty);
    }
}
