﻿using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneMenu
{
    [MenuItem("Scenes/Menu")]
    public static void OpenMenu()
    {
        OpenScene("Menu");
    }

    [MenuItem("Scenes/Factory")]
    public static void OpenGame()
    {
        OpenScene("FactoryBuild");
    }

    private static void OpenScene(string sceneName)
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Persistent.unity", OpenSceneMode.Single);
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
}