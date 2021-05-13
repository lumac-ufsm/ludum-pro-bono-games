using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButtonTheLostBrains : MonoBehaviour {
	private Animator animator;
    [SerializeField] private ControlledActivationMonoBehaviour[] controlledActivations;

	void Start() {
		animator = GetComponent<Animator>();
	}

	public void Press() {
        animator.Play("Press");
    }
}
