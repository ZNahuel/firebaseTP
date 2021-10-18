using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;

    User user = new User();

    public static string playerName;
    public static string playerScore;

    public Script_Puntaje SP;

    void Start()
    {
        scoreText.text = SP.Tempo.text;
        playerScore = SP.Tiempo.ToString(); 
    }

    private void UpdateScore()
    {
        scoreText.text = "Tiempo: " + user.userScore;
    }

    private void PostToDataBase()
    {
        User user = new User();
        RestClient.Put("https://simuladores-b1442-default-rtdb.firebaseio.com/" + playerName + ".json", user);
    }
    public void OnSubmit()
    {
        playerName = nameText.text;
        playerScore = SP.Tiempo.ToString();
        PostToDataBase();
    }
    private void RetrieveFromDataBase()
    {
        RestClient.Get<User>("https://simuladores-b1442-default-rtdb.firebaseio.com/" + nameText.text + ".json").Then(response =>

        {
            user = response;
            UpdateScore();
        });
    }
    public void OnGetScore()
    {
        RetrieveFromDataBase();
    }
}



