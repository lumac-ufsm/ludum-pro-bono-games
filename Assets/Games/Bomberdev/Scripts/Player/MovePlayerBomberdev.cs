using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBomberdev : MonoBehaviour {
	private TranslationBomberdev translation = null;
	private Vector2 oldPosition;
	private Rigidbody2D playerRigidbody2D;
	[SerializeField] private float forceIntensity = 1;

	private void Start() {
		playerRigidbody2D = GetComponent<Rigidbody2D>();
		oldPosition = transform.position;
	}

	private void Update() {
		Run();
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Bomb")) {
			Stop();
		}
	}

	public void Translate(Direction direction, int numberOfSteps, Func.Callback callback) {
		translation = new TranslationBomberdev(direction, numberOfSteps, callback);
	}

	private Vector2 CalcNextPosition(Vector2 currentPosition, Direction direction, int numberOfSteps) {
		Vector2 translate = Vector2.zero;
		switch (direction) {
			case Direction.UP:
				translate = numberOfSteps * new Vector2(0, 1);
				break;
			case Direction.DOWN:
				translate = numberOfSteps * new Vector2(0, -1);
				break;
			case Direction.LEFT:
				translate = numberOfSteps * new Vector2(-1, 0);
				break;
			case Direction.RIGHT:
				translate = numberOfSteps * new Vector2(1, 0);
				break;
		}

		Vector2 position = currentPosition + translate;
		return position;
	}

	private void Run() {
		if (translation != null) {
			Direction direction = translation.direction;
			Vector2 currentPosition = transform.position;
			int numberOfSteps = translation.numberOfSteps;
			Vector2 nextPosition = CalcNextPosition(oldPosition, direction, numberOfSteps);

			bool endTranslate = currentPosition == nextPosition;

			if (direction == Direction.RIGHT) endTranslate = currentPosition.x >= nextPosition.x;
			else if (direction == Direction.LEFT) endTranslate = currentPosition.x <= nextPosition.x;
			else if (direction == Direction.UP) endTranslate = currentPosition.y >= nextPosition.y;
			else if (direction == Direction.DOWN) endTranslate = currentPosition.y <= nextPosition.y;

			if (endTranslate) {
				Stop();
			} else {
				if (direction == Direction.DOWN || direction == Direction.UP) {
					playerRigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
				} else if (direction == Direction.LEFT || direction == Direction.RIGHT) {
					playerRigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
				}
				Vector2 force = nextPosition - currentPosition;
				force *= forceIntensity;
				playerRigidbody2D.AddForce(force, ForceMode2D.Impulse);
			}
		}
	}

	private void Stop() {
		playerRigidbody2D.Sleep();
		playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		Vector2 position = transform.position;
		position.x = Mathf.Round(position.x);
		position.y = Mathf.Round(position.y);
		transform.position = position;
		oldPosition = position;
		Func.Callback callback = translation.callback;
		translation = null;
		callback();
	}
}
