using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager2 : MonoBehaviour
{
	// Instance
	public static SceneManager2 Manager;

	// Componenets
	private Animator anim;

    void Awake() {
		Manager = this;
		GetComponents();
	}

	// Get Components
	private void GetComponents()
	{
		anim = GetComponentInChildren<Animator>();
	}

	// Transitions into a Scene
	public void Transition(string sceneName) {
        anim.SetTrigger("transition");
        StartCoroutine(LoadScene(sceneName));
    }

	// Loads a Scene in time
    private IEnumerator LoadScene(string sceneName) {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
