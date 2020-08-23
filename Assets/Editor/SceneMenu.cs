using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneMenu
{
    [MenuItem("Scenes/House")]
    public static void OpenTheatre()
    {
        OpenScene("House");
    }

    [MenuItem("Scenes/Factory")]
    public static void OpenFactory()
    {
        OpenScene("Factory");
    }

    [MenuItem("Scenes/Telephone")]
    public static void OpenTelephone()
    {
        OpenScene("Telephone");
    }

    private static void OpenScene(string sceneName)
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Persistent.unity", OpenSceneMode.Single);
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
}