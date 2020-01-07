using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleThreeRemake : MonoBehaviour
{
    [SerializeField] Area field;
    [SerializeField] Transform parent;
    [SerializeField] Image playerBase;
    [SerializeField] int playerX;
    [SerializeField] int playerY;
    [SerializeField] Image forward;
    [SerializeField] Image left;
    [SerializeField] Image right;

    public Button buttonAssign;
    public static Button button;

    static float queuePos;
    static bool canExecute = true;
    static Queue<Image> orderImages = new Queue<Image>();
    static Queue<MoveOrder> orders = new Queue<MoveOrder>();
    static Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    static int currentX;
    static int currentY;
    static int currentDir;
    static Image player;
    static Area[,] fields = new Area[14, 6];
    public static Area selectedField;
    public static bool fieldSelected;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData.gamestate = 3;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        button = buttonAssign;
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                fields[i, j] = Instantiate(field, new Vector3(-8.2f + (i * 1f), -4.6f + (j * 1f), 0), Quaternion.identity, parent);
                fields[i, j].name = "[" + i + "," + j + "]";
                fields[i, j].x = i;
                fields[i, j].y = j;
            }
        }

        player = Instantiate(playerBase, new Vector3(-8.2f + (playerX * 1f), -4.6f + (playerY * 1f), 0), Quaternion.identity, parent);
        player.name = "player";

        currentX = playerX;
        currentY = playerY;

        SetupPlayArea();

        Destroy(field.gameObject);
        Destroy(playerBase.gameObject);
    }

    private static void SetupPlayArea()
    {
        foreach (Area f in fields)
        {
            f.canAccess = true;
            f.isTarget = false;
        }

        fields[9,2].canAccess = false;
        fields[9,2].canAccess = false;
        fields[10,2].canAccess = false;
        fields[10,3].canAccess = false;
        fields[11,2].canAccess = false;
        fields[11,3].canAccess = false;
        fields[4, 5].canAccess = false;
        fields[5, 5].canAccess = false;
        fields[4, 4].canAccess = false;
        fields[5, 4].canAccess = false;
        fields[5, 3].canAccess = false;
        fields[5, 2].canAccess = false;
        fields[7, 0].canAccess = false;
        fields[7, 1].canAccess = false;
        fields[8, 5].canAccess = false;
        fields[8, 4].canAccess = false;
        fields[1, 1].canAccess = false;
        fields[1, 2].canAccess = false;
        fields[2, 1].canAccess = false;
        fields[2, 2].canAccess = false;
        fields[3, 1].canAccess = false;
        fields[3, 2].canAccess = false;


        fields[12,4].isTarget = true;

        ColorPlayArea();
    }

    private static void ColorPlayArea()
    {
        foreach (Area f in fields)
        {
            if(f.canAccess)
            {
                if (f.isTarget)
                {
                    f.GetComponent<Image>().color = Color.blue;
                }
                else
                {
                    f.GetComponent<Image>().color = Color.white;
                }
            } else
            {
                f.GetComponent<Image>().color = Color.grey;
            }   
        }
    }

    public void AddForwardOrder()
    {
        orderImages.Enqueue(Instantiate(forward, new Vector3(6.25f + (queuePos * 1f), 0, 0), Quaternion.identity, parent));
        orders.Enqueue(MoveOrder.forward);
        queuePos += .1f;
    }

    public void AddLeftOrder()
    {
        orderImages.Enqueue(Instantiate(left, new Vector3(6.25f + (queuePos * 1f), 0, 0), Quaternion.identity, parent));
        orders.Enqueue(MoveOrder.left);
        queuePos += .1f;
    }

    public void AddRightOrder()
    {
        orderImages.Enqueue(Instantiate(right, new Vector3(6.25f + (queuePos * 1f), 0, 0), Quaternion.identity, parent));
        orders.Enqueue(MoveOrder.right);
        queuePos += .1f;
    }

    public void Execute()
    {
        if (canExecute)
        {
            canExecute = false;
            StartCoroutine(ExecuteMoves());
        }
    }

    public System.Collections.IEnumerator ExecuteMoves()
    {
        foreach (MoveOrder m in orders)
        {
            Image tempImage = orderImages.Dequeue();
            tempImage.transform.position = new Vector3(tempImage.transform.position.x - .5f, tempImage.transform.position.y, tempImage.transform.position.z);
            foreach(Image i in orderImages)
            {
                i.transform.position = new Vector3(i.transform.position.x - .1f, i.transform.position.y, i.transform.position.z);
            }
            Destroy(tempImage.gameObject);

            switch (m)
            {
                case MoveOrder.forward:
                    player.transform.position = new Vector3(player.transform.position.x + directions[currentDir].x, player.transform.position.y + directions[currentDir].y);
                    currentX += (int)directions[currentDir].x;
                    currentY += (int)directions[currentDir].y;
                    break;
                case MoveOrder.left:
                    currentDir = (currentDir + 3) % 4;
                    player.transform.Rotate(0, 0, -90);
                    break;
                case MoveOrder.right:
                    currentDir = (currentDir + 1) % 4;
                    player.transform.Rotate(0, 0, 90);
                    break;
            }
            if (currentX > 13 || currentX < 0 || currentY > 5 || currentY < 0 || !fields[currentX, currentY].canAccess)
            {
                yield return new WaitForSecondsRealtime(.5f);
                player.transform.position = new Vector3(player.transform.position.x - directions[currentDir].x * .75f, player.transform.position.y - directions[currentDir].y * .75f);
                break;
            }
            if (fields[currentX, currentY].isTarget)
            {
                ClearPuzzle();
                break;
            }
            yield return Wait();
        }
    }

    public System.Collections.IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(.25f);
    }

    public static void ResetField()
    {
        foreach (Image i in orderImages) Destroy(i.gameObject);
        orderImages = new Queue<Image>();
        orders = new Queue<MoveOrder>();
        queuePos = 0.0f;
        canExecute = true;
        player.transform.position = new Vector3(-8.2f + (1 * 1f), -4.6f + (4 * 1f), 0);
        player.transform.rotation = Quaternion.identity;
        currentDir = 0;
        currentX = 1;
        currentY = 4;
    }

    public static bool CheckAnswer()
    {
        if (currentX > 13 || currentX < 0 || currentY > 5 || currentY < 0)
        {
            return false;
        }
        else
        {
            return fields[currentX, currentY].isTarget;
        }
    }

    public static void ClearPuzzle()
    {
        button.onClick.Invoke();
    }
}