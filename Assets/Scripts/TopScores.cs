using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class TopScores : MonoBehaviour
{

    //this is set by EndGame and used to compare if the player is in the Top10 returned by the server, or otherwise add it as the 11th result
    public static Score player;

    public static void SetPlayer(string id, string name, int score, string category)
    {
        player = new Score();
        player.id = id;
        player.name = name;
        player.score = score;
        player.category = category;
        player.time = new DateTime();
    }

    //Have a button point to this to exit
    public void Quit()
    {
        Application.Quit();
    }

    //you'll need to set this in unity as the parent 'Scores' object shown above
    public GameObject scorePanel;
    protected List<Score> scores = new List<Score>();
    protected void Start()
    {
        DownloadScores();
    }

    protected void DownloadScores()
    {

       /*HTTP.Request theRequest = new HTTP.Request("get", "https://simuladores-b1442-default-rtdb.firebaseio.com/ "score"&limitToLast=10");
        someRequest.Send((request) => {
            Hashtable decoded = (Hashtable)JSON.JsonDecode(request.response.Text);
            if (decoded == null)
            {
                Debug.LogError("server returned null or     malformed response ):");
                return;
            }

            foreach (DictionaryEntry json in decoded)
            {
                Hashtable jsonObj = (Hashtable)json.Value;
                Score s = new Score();
                s.id = (string)json.Key;
                s.name = (string)jsonObj["name"];
                s.score = (int)jsonObj["score"];
                s.category = (string)jsonObj["cat"];
                //gotta convert it!
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                s.time = dtDateTime.AddMilliseconds((long)jsonObj["time"]).ToLocalTime();

                scores.Add(s);
            }
            AddScores();
        });
   */ }

    protected void AddScores()
    {
        //no dupes
        if (!scores.Contains(player))
        {
            scores.Add(player);
        }
        //firebase usually returns sorted content, but that's not guaranteed by the JSON format
        scores.Sort((Score x, Score y) => { return x.score.CompareTo(y.score); });

        //we'll be filling top to bottom
        scores.Reverse();

        int i = 0;
        foreach (Score s in scores)
        {
            if (i > 10)
            {
                break;
            }
            Transform panel = scorePanel.transform.Find("Panel " + i);
            panel.Find("score").GetComponent<Text>().text = s.score + "";
            panel.Find(s.category).gameObject.SetActive(true);
            panel.Find("name").GetComponent<Text>().text = s.name;
            if (!s.Equals(player))
            {
                //the player might not come from the server, so 'time' will be null
                panel.Find("time").GetComponent<Text>().text = s.time.ToString("yyyy-MM-dd");
            }
            i++;
        }
    }

    public class Score
    {
        public string id;
        public string name;
        public int score;
        public string category;
        public DateTime time;

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Score s = obj as Score;
            if ((System.Object)s == null)
            {
                return false;
            }
            return id == s.id;
        }
    }
}