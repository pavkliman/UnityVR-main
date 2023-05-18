using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using TMPro;
using System.Linq;

public class Connection : MonoBehaviour
{
    private TextMeshProUGUI panelTTS;
    private TextMeshProUGUI[] textOnCanvas;

    private void Awake()
    {
        setConnection();   
    }

    private void Start()
    {
        // Find all Text objects in the scene
        TextMeshProUGUI[] allText = FindObjectsOfType<TextMeshProUGUI>();

        // Filter out only the Text objects that belong to the specified Canvas
        textOnCanvas = allText.Where(text => text.transform.parent.name == "TTSPanel").ToArray();

        // Print the names of the Text objects found on the Canvas
        

        setTextInTTSPanel();
    }

    public int getPanelLenght 
    {
        get { return textOnCanvas.Length; }
    }

    public void setConnection()
    {
        string path = Application.dataPath + "/StreamingAssets/test.db";
        string sqlCommandText = "Select infomodel FROM informationmodel WHERE namemodel = 'Teploobmennik_Ispr_2'";

        SqliteConnection connection = new SqliteConnection("Data Source =" + path);
        connection.Open();
        if (connection.State == ConnectionState.Open)
        {
            SqliteCommand sqliteCommand = new SqliteCommand();
            sqliteCommand.Connection = connection;
            sqliteCommand.CommandText = sqlCommandText;
            SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();

            while (sqliteDataReader.Read())
            {
                var id = sqliteDataReader.GetValue(0);

                //object id = sqliteDataReader[0];
                //object id = sqliteDataReader["id"];
                //string id = sqliteDataReader["id"].ToString();
                string namemodel = sqliteDataReader["infomodel"].ToString();
                //string infomodel = sqliteDataReader["infomodel"].ToString();
                Debug.Log(namemodel);
            }
        }
        connection.Close();
    }

    public void setTextInTTSPanel()
    {
        string path = Application.dataPath + "/StreamingAssets/test.db";
        string sqlCommandText = "Select textfortts FROM tts";
        int lenghtPanel = getPanelLenght; 
        SqliteConnection connection = new SqliteConnection("Data Source =" + path);
        connection.Open();
        if (connection.State == ConnectionState.Open)
        {
            SqliteCommand sqliteCommand = new SqliteCommand();
            sqliteCommand.Connection = connection;
            sqliteCommand.CommandText = sqlCommandText;
            SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
            int i = 0;
            while (sqliteDataReader.Read() && i < lenghtPanel)
            {
               
                string textfortts = sqliteDataReader["textfortts"].ToString();
                textOnCanvas[i].text = textfortts;
                Debug.Log(textfortts);
                Debug.Log(textOnCanvas[i]);
                Debug.Log(textOnCanvas[i].text);
                //string infomodel = sqliteDataReader["infomodel"].ToString();
                textOnCanvas[i].enabled = false;
                i += 1;
            }
        }
        connection.Close();
    }
}
