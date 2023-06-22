using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaVincent.Lab3;

namespace JiaVincent.Lab3
{
    public class EventManager : MonoBehaviour
    {
        public void GameOver()
        {
            GameOver gameOver = FindObjectOfType<GameOver>();
            gameOver.DisplayScreen();
        }
    }
}