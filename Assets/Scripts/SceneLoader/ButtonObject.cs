using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    public Animator animator;

    public void LoadGame()
    {
        SceneLoader.Instance.LoadNewScene("FactoryBuild");
    }

    public void LoadTheatre()
    {
        SceneLoader.Instance.LoadNewScene("Menu");
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadGame();
        animator.SetTrigger("Click");
    }
}
