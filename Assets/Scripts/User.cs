using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class User
{
    public string userName;
    public string userScore;

    public User()
    {
        userName = PlayerScores.playerName;
        userScore = PlayerScores.playerScore.ToString();
    }
}

