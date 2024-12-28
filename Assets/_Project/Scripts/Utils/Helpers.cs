using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utilities
{
    public static class Helpers
    {
        public static void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
