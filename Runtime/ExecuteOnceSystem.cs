using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SimpleMan.Utilities
{
    /// <summary>
    /// Gives ability to excecute the method once per frame
    /// without any checking from the caller side
    /// </summary>
    public static class ExecuteOnceSystem
    {
        private static List<Action> _frameActions = new List<Action>(100);
        private static bool _running = false;




        //------METHODS
        public static void ExecuteOncePerFrame(Action action)
        {
            _frameActions.AddUnique(action);

            if (!_running)
                StartAsync();
        }

        private static async void StartAsync()
        {
            _running = true;
            if (_frameActions.Count == 0)
            {
                _running = false;
                return;
            }

            //Wait frame
            await Task.Yield();

            //Invoke actions in immidiate list
            for (int i = 0; i < _frameActions.Count; i++)
                _frameActions[i]?.Invoke();

            //Clear action list
            _frameActions.Clear();

            //Is game stopped? -> break
            if (!Application.isPlaying)
            {
                _running = false;
                return;
            }
            _running = false;
        }
    }
}