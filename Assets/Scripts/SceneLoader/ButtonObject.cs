using UnityEngine;

public class SceneCaller : MonoBehaviour
{
    public void LoadTheatre()
    {
        SceneLoader.Instance.LoadNewScene("Theatre");
    }

    public void LoadFactory()
    {
        SceneLoader.Instance.LoadNewScene("Factory");
    }


    public void LoadTelephone()
    {
        SceneLoader.Instance.LoadNewScene("Telephone");
    }
}
