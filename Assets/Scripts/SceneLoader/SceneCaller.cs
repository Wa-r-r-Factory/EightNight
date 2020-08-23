using UnityEngine;

public class SceneCaller : MonoBehaviour
{
    public void LoadHouse()
    {
        SceneLoader.Instance.LoadNewScene("House");
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
