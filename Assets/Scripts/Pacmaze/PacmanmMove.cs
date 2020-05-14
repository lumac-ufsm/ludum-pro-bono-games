using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanmMove : MonoBehaviour
{

    public bool permitirMovimento = true;
    public float velocidade;
    public Vector3 direcao;
    public Collider2D colliderUp;
    public Collider2D colliderDown;
    public Collider2D colliderLeft;
    public Collider2D colliderRight;
    public Animator animator;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    // Use this for initialization
    void Start()
    {
        direcao = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        up = colliderUp.IsTouchingLayers();
        down = colliderDown.IsTouchingLayers();
        left = colliderLeft.IsTouchingLayers();
        right = colliderRight.IsTouchingLayers();

        if (permitirMovimento)
        {
            if (Input.GetKeyDown(Keys.left))
                if (!colliderLeft.IsTouchingLayers()) mover(Vector3.left);

            if (Input.GetKeyDown(Keys.right))
                if (!colliderRight.IsTouchingLayers()) mover(Vector3.right);

            if (Input.GetKeyDown(Keys.up))
                if (!colliderUp.IsTouchingLayers()) mover(Vector3.up);

            if (Input.GetKeyDown(Keys.down))
                if (!colliderDown.IsTouchingLayers()) mover(Vector2.down);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direcao * velocidade);
        animator.SetFloat("x", direcao.x);
        animator.SetFloat("y", direcao.y);
    }

    private void parar()
    {
        permitirMovimento = true;
        direcao = Vector3.zero;
    }

    private void mover(Vector2 direcao)
    {
        this.direcao = direcao;
        permitirMovimento = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        parar();
        print(other.gameObject.name);
    }
}
