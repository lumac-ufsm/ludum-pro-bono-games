using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public GameObject[] foodsPrefab;
    public int[] valuesFood;
    public int[] nFoods;
    private Vector3 direction;
    public float speedGame = 1;
    public int deslocamentoTela;
    public GameObject bodyPrefab;
    public GameObject gameArea;
    public int sumValues;
    public Text textSum;
    public Text textExpression;
    public float time;
    public Text textTime;
    private float timeMove;
    private bool permitirMovimento;
    private float screenHeight;
    private float screenWidth;
    private float maxX, minX, maxY, minY;
    private List<GameObject> listBody;
    private Vector3 positionOld;
    private int resultadoDesafio;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2;
        screenWidth = screenHeight / Screen.height * Screen.width;

        screenHeight = Mathf.Floor(screenHeight);
        screenHeight += screenHeight % 2 == 0 ? -1 : 0;
        screenWidth = Mathf.Floor(screenWidth);
        screenWidth += screenWidth % 2 == 0 ? -1 : 0;
        screenHeight -= deslocamentoTela * 2;

        gameArea.transform.Translate(new Vector3(0, -deslocamentoTela, 0));

        maxX = (screenWidth - 1) / 2;
        minX = -maxX;
        maxY = ((screenHeight - 1) / 2);
        minY = -maxY;
        maxY -= deslocamentoTela;
        minY -= deslocamentoTela;

        gameArea.transform.localScale = new Vector2(screenWidth, screenHeight);

        listBody = new List<GameObject>();

        GameObject food = Instantiate(foodsPrefab[0]);
        sortPositionFood(food);

        for (int n = 0; n < foodsPrefab.Length; n++)
        {
            for (int m = 0; m < nFoods[n]; m++)
            {
                criarFood(foodsPrefab[n], valuesFood[n]);
            }
        }

        addBody();
        gerarDesafio();
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs
        if (permitirMovimento)
        {
            if (Input.GetKeyDown(Keys.left) && direction.x <= 0)
            {
                direction = Vector3.left;
                permitirMovimento = false;
            }
            else if (Input.GetKeyDown(Keys.right) && direction.x >= 0)
            {
                direction = Vector3.right;
                permitirMovimento = false;
            }
            else if (Input.GetKeyDown(Keys.up) && direction.y >= 0)
            {
                direction = Vector3.up;
                permitirMovimento = false;
            }
            else if (Input.GetKeyDown(Keys.down) && direction.y <= 0)
            {
                direction = Vector3.down;
                permitirMovimento = false;
            }
        }

        // Movimentação Snake
        timeMove += Time.deltaTime;
        if (timeMove >= 1 / speedGame)
        {
            timeMove = 0;

            positionOld = transform.position;
            transform.Translate(direction);

            for (int n = listBody.Count - 1; n > 0; n--)
            {
                listBody[n].transform.position = listBody[n - 1].transform.position;
            }
            listBody[0].transform.position = positionOld;
            permitirMovimento = true;
        }

        // Campo
        Vector3 position = transform.position;
        if (position.x < minX) position.x = maxX;
        else if (position.x > maxX) position.x = minX;
        else if (position.y < minY) position.y = maxY;
        else if (position.y > maxY) position.y = minY;
        transform.position = position;

        // Tempo
        if (time <= 0)
        {
            textTime.text = "0";
            gameOver();
        }
        else
        {
            time -= Time.deltaTime;
            textTime.text = Mathf.Round(time).ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ao colidir com food
        if (other.gameObject.name.Contains("Food"))
        {
            string name = other.gameObject.name;
            int value = int.Parse(name.Replace("(Clone)", "").Replace("Food-", ""));
            if (value == 0) sumValues = 0;
            else sumValues += value;
            sortPositionFood(other.gameObject);

            // Desafio completo
            if (resultadoDesafio == sumValues)
            {
                addBody(2);
                sumValues = 0;
                time += 30;
                gerarDesafio();
            }
            textSum.text = sumValues.ToString();
        }

        if (other.gameObject.CompareTag("Player") && listBody.Count > 1)
        {
            gameOver();
        }
    }

    private void criarFood(GameObject foodPrefab, int value)
    {
        GameObject food = Instantiate(foodPrefab);
        sortPositionFood(food);
    }

    private void sortPositionFood(GameObject food)
    {
        food.transform.position = new Vector3(
                    Mathf.Round(Random.Range(minX, maxX)),
                    Mathf.Round(Random.Range(minY, maxY)), 0);
    }

    private void addBody()
    {
        GameObject body = Instantiate(bodyPrefab);
        body.transform.position = positionOld;
        listBody.Add(body);
    }

    private void addBody(int num)
    {
        for (int n = 0; n < num; n++)
        {
            addBody();
        }
    }

    private void gameOver()
    {
        SnakeStorage.points = listBody.Count;
        SceneManager.LoadScene("Scenes/SnakeCalculator/GameOver");
    }

    private void gerarDesafio()
    {
        int n1 = Random.Range(1, listBody.Count * 5);
        int n2 = Random.Range(1, listBody.Count * 5);
        textExpression.text = n1 + " + " + n2 + " = ?";
        resultadoDesafio = n1 + n2;
    }
}
