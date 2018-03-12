using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
//referencing instruction from answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html

public class DatabaseManager : MonoBehaviour {

    public string playerName;
    public int score;
    public bool finish_game;
    private string conn;
	// Use this for initialization
	void Start ()
    {
        conn = "URI=file:" + Application.dataPath + "/DataBase/SchoolDatabase.db";
        CreateTable();
    }

	// Update is called once per frame
	void Update () {
        
	}

    IEnumerable CreateTable()
    {
        using (IDbConnection dbconn = new SqliteConnection(conn))
        {

            dbconn.Open();
            //making a DB command: CREATE TABLE
            using (IDbCommand dbCmd = dbconn.CreateCommand())
            {
                //create the DB table if it doesn't exist
                string sqlQuery = String.Format("CREATE TABLE if not exists highscore ( id INT PRIMARY KEY AUTOINCREMENT , name VARCHAR(3), score INTEGER, finish_game BOOLEAN) ");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbconn.Close();
            }
        }
        //Path to database.
        return null;
    }

    public string DisplayResult(string input)
    {
        string result = input+"\n\n";
        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            using (IDbCommand dbCmd = dbconn.CreateCommand())
            {
                string sqlQuery = String.Format("SELECT name, score from highscore");
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //string name = reader.GetString(1);
                        string temp_name = reader.GetString(0);
                        int temp_score = reader.GetInt32(1);
                        result =  result +"\n"+ temp_name +"                   "+ temp_score;
                    }
                    dbconn.Close();
                    reader.Close();
                }
            }
        }
        
        return result;
    }

    public void AddResult(string name, int score, bool finish_game)
    {
        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            using (IDbCommand dbCmd = dbconn.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO highscore ('name','score','finish_game') VALUES('"+name+ "', '" + score + "', '" + finish_game + "')");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbconn.Close();
                
            }
        }
        
    }
   
}

