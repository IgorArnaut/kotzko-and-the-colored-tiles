using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager2 : MonoBehaviour
{
	// Instanca
	public static SceneManager2 Manager;

	// Komponente
	private Animator anim;

    void Awake() {
		Manager = this;
		GetComponents();
	}

	// Uzima komponente
	private void GetComponents()
	{
		anim = GetComponentInChildren<Animator>();
	}

	// Menja se u scenu
	public void Transition(string sceneName) {
        anim.SetTrigger("transition");
        StartCoroutine(LoadScene(sceneName));
    }

	// Pokrece scenu posle nekog vremena
    private IEnumerator LoadScene(string sceneName) {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
