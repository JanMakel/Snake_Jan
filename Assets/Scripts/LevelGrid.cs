using UnityEngine;

public class LevelGrid
{
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    
    private int width;
    private int height;

    private Snake snake;

    private int foodNum;
    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            if (foodGameObject.CompareTag("apple"))
            {
                Score.AddScore(Score.APPLEPOINTS);
            }
            else if (foodGameObject.CompareTag("cake"))
            {
                Score.AddScore(Score.CAKEPOINTS);
            }
            else if (foodGameObject.CompareTag("pizza"))
            {
                Score.AddScore(Score.PIZZAPOINTS);
            }
            Object.Destroy(foodGameObject);
            SpawnFood();
             
            
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpawnFood()
    {
       
        
        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);
        
        foodGameObject = new GameObject("Food");
        foodNum = Random.Range(0, 3);
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite[foodNum];
        if (foodNum == 0)
        {
            foodGameObject.gameObject.tag = "apple";
        }
        else if (foodNum == 1)
        {
            foodGameObject.gameObject.tag = "cake";
        }
        else if (foodNum == 2)
        {
            foodGameObject.gameObject.tag = "pizza";
        }
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
      
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);
        
        // Me salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        if (gridPosition.x < -w)
        {
            gridPosition.x = w;
        }
        if (gridPosition.y > h)
        {
            gridPosition.y = -h;
        }
        if (gridPosition.y < -h)
        {
            gridPosition.y = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}