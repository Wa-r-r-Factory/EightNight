using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneMenu
{
    [MenuItem("Scenes/Theatre")]
    public static void OpenTheatre()
    {
        OpenScene("Theatre");
    }

    [MenuItem("Scenes/Factory")]
    public static void OpenFactory()
    {
        OpenScene("Factory");
    }

    private static void OpenScene(string sceneName)
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Persistent.unity", OpenSceneMode.Single);
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
}