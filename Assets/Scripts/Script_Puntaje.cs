using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_Puntaje : MonoBehaviour

{
    public Text Tempo;
    public float Tiempo = 0.0f;
    public bool DebeAumentar = false;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != (null))
        {

            if (DebeAumentar)
                Tiempo += Time.deltaTime;
     
            else
            {
                if (Tiempo <= 0.0f)  
                {
                    DebeAumentar = true;
                }
                else
                {
                    Tiempo -= Time.deltaTime;
                }
            }

            Tempo.text = "Tiempo:" + " " + Tiempo.ToString("f0");
        }
    }

}