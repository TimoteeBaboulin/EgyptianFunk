using System;
using UnityEngine;

namespace Timotee.Scripts.Player{
    public static class GameManager{
        public static event Action<bool> OnPause; 

        public static bool IsPaused => _isPaused;
        private static bool _isPaused = false;

        public static void StartPause(){
            _isPaused = true;
            OnPause?.Invoke(_isPaused);
        }

        public static void StopPause(){
            _isPaused = false;
            OnPause?.Invoke(_isPaused);
        }
    }
}