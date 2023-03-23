using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	//Выход из игры (кнопка ВЫХОД)
    public void Exit()
    {
        Application.Quit();
    }
	
	//Открытие идеи (кнопка ИДЕЯ)
    public void Idea()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=s0Je9krN54w");
    }
	
	//Открытие ФифтиГеймс (кнопка СОЗДАТЕЛЬ)
    public void Owner()
    {
        Application.OpenURL("https://vk.com/fiftyGames");
    }
	
	//Открытие ДонатионАлертс (кнопка ДОНАТ)
    public void Donate()
    {
        Application.OpenURL("https://www.donationalerts.com/r/fiftygames");
    }
}
