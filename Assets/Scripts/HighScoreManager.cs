using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
public class HighScoreManager : MonoBehaviour {
    public GameObject scorePrefab;

    private string connectionString;

    private List<HighScore> highScores = new List<HighScore>();

    public Transform scoreParent;

    public int topRanks;

    public int saveScores;

    public Text enterName;

    public GameObject nameDialog;

    private GameObject toBeDestroyed;

	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/HightScoreDb.sqlite";
        Debug.Log(" sql lite file place " + connectionString );
        CreateTable();
        ShowScores();
        DeleteExtraScore();
        nameDialog.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

	}

    private void CreateTable()//creating a table in sql lite
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("CREATE TABLE if not exists HighScores (PlayerID INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , Name TEXT NOT NULL , Score INTEGER NOT NULL , Date DATETIME NOT NULL  DEFAULT CURRENT_DATE, Timer TEXT NOT NULL  DEFAULT 0, WrongAnswers INTEGER NOT NULL  DEFAULT 0)");
                 
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    public void EnterName() //session where user enter his name and catches his DATA
    {
        if (enterName.text != string.Empty)
        {
            int score = FindObjectOfType<GameSession>().currentScore;
            string timer = FindObjectOfType<GameSession>().timerTime;
            int WrongAnswers = 5 - FindObjectOfType<GameSession>().currHealth;
            InsertScore(enterName.text, score,timer, WrongAnswers);
            enterName.text = string.Empty;
            ShowScores();
        }
        nameDialog.SetActive(false);
        toBeDestroyed = GameObject.Find("GameSession");
        Destroy(toBeDestroyed);
    }
    private void InsertScore(string name,int newScore,string timer,int WrongAnswers) // SQL Order BY
    {

        GetScores();
        int hsCount = highScores.Count;
        if(highScores.Count>0)
        {
            HighScore lowestScore = highScores[highScores.Count - 1];
            if(lowestScore != null && saveScores > 0 && highScores.Count >= saveScores && newScore > lowestScore.Score)
            {
                DeleteScore(lowestScore.ID);
                hsCount--;
            }
        }


        if (hsCount< saveScores) 
        {
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = string.Format("INSERT INTO HighScores(Name,Score,Timer,WrongAnswers) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", name, newScore,timer,WrongAnswers);

                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbConnection.Close();

                }
            }
        }

    }
    private void GetScores() // Catch scores from DB
    {
        highScores.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        highScores.Add(new HighScore( reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
                        
                    }
                    dbConnection.Close();
                    reader.Close();

                }
            }
        }
        highScores.Sort();
    }


    private void DeleteScore(int id) 
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"",id);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }





    private void ShowScores() // printing in the screen 
    {
        GetScores();


        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            Destroy(score);
        }


        for (int i=0;i<topRanks;i++)
        {
            if (i <= highScores.Count - 1)
            {
                GameObject tmpObject = Instantiate(scorePrefab);

                HighScore tmpScore = highScores[i];

                tmpObject.GetComponent<HighScoreScript>().setScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (1 + i).ToString());

                tmpObject.transform.SetParent(scoreParent);

                tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }

    }

    private void DeleteExtraScore()// deleting the extra scores that getted out of the range
    {
        GetScores();
        if(saveScores <= highScores.Count )
        {
            int deleteCount = highScores.Count - saveScores;
            highScores.Reverse();

            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    for (int i = 0; i < deleteCount; i++)
                    {
                        string sqlQuery = string.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", highScores[i].ID);

                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                    }

                    dbConnection.Close();
                }

            }

        }

    }

}
