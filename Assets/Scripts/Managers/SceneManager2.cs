using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager2 : MonoBehaviour
{
	public static SceneManager2 Manager;

	private Animator anim;

    void Awake() {
		Manager = this;
		anim = GetComponentInChildren<Animator>();
    }

    public void Transition(string sceneName) {
        anim.SetTrigger("transition");
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName) {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
