using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public bool isPlayerSelected;
    private int[,] availableMovesArray = new int[8,8];
    public LayerMask cellLayer;
    private int id;
    [SerializeField]private GameObject availableMovesPrefab;
    private Stack<GameObject> availableMovesPrefabStack= new Stack<GameObject>();
    private float cooldownTimer = 0.0f; // òàéìåð äëÿ îòñëåæèâàíèÿ êóëäàóíà
    private bool isOnCooldown = false; // ôëàã àêòèâíîãî êóëäàóíà
    private float cooldownTime;
    private bool isShowing = false;
    [SerializeField] private GameObject ElefantCDBar;
    [SerializeField] private GameObject HorseCDBar;
    [SerializeField] private GameObject RookCDBar;
    [SerializeField] private GameObject elGuardCDBar;
    Hero hero;

    void Update()
    {
        if (isPlayerSelected && !isOnCooldown)
        {
            ShowAvailableMoves(id);
            if (!isShowing)
            {
                InstantateAwailableMoves();
            }
            GoToCell();
        }
        else 
        {
            ClearTheMap();
            cooldownTimer -= Time.deltaTime; // óìåíüøàåì òàéìåð êóëäàóíà
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;
            }
        }
    }

    private void Start()
    {
        id = hero.HeroStats.id;
    }

    void Awake()
    {
        hero = GetComponent<Hero>();
        cellLayer = LayerMask.GetMask("Cell");
        cooldownTime = hero.HeroStats.cooldownTimeMovement;
    }

    private void ShowAvailableMoves(int id)
    {
        if (id == 0)
        {
            ForRookMovement();
        }
        else if (id == 1)
        {
            ForElephantMovement();
        }
        else if (id == 2)
        {
            ForHorseMovement();
        } 
        else if (id == 4)
        {
            ElectricGuardMovement();
        }

        if (hero.HeroStats.idBattleModule == 3)
        {
            SunStep();
        }
    }

    private void ElectricGuardMovement()
    {
        if ((int)transform.position.z - 1 >= 0 
            && MazeManager.mapArray[(int)transform.position.x, (int)transform.position.z - 1] == 0)
        {
            availableMovesArray[(int)transform.position.x, (int)transform.position.z - 1] = 1;
        }
    }

    private void SunStep()
    {
        for (int i = 1; i <= 2; i++)
        {
            if ((int)transform.position.z + i >= 0 && (int)transform.position.z + i < 8 
                && MazeManager.mapArray[(int)transform.position.x, (int)transform.position.z + i] == 0)
            {
                availableMovesArray[(int)transform.position.x, (int)transform.position.z + i] = 1;
            }
        }
        
    }

    private void ForRookMovement()
    {
        for (int i = (int)transform.position.x; i < 8; i++)
        {
            if (i != (int)transform.position.x)
            {
                if (MazeManager.mapArray[i, (int)transform.position.z] == 0)
                {
                    availableMovesArray[i, (int)transform.position.z] = 1;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = (int)transform.position.x; i >= 0; i--)
        {
            if (i != (int)transform.position.x && i >= 0)
            {
                if (MazeManager.mapArray[i, (int)transform.position.z] == 0)
                {
                    availableMovesArray[i, (int)transform.position.z] = 1;
                }
                else
                {
                    break;
                }
            }
        }

        for (int j = (int)transform.position.z; j < 8; j++)
        {
            if (j != (int)transform.position.z)
            {
                if (MazeManager.mapArray[(int)transform.position.x, j] == 0)
                {
                    availableMovesArray[(int)transform.position.x, j] = 1;
                }
                else
                {
                    break;
                }
            }
        }

        for (int j = (int)transform.position.z; j >= 0; j--)
        {
            if (j != (int)transform.position.z && j >= 0)
            {
                if (MazeManager.mapArray[(int)transform.position.x, j] == 0)
                {
                    availableMovesArray[(int)transform.position.x, j] = 1;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void ForElephantMovement()
    {
        for (int i = 1; i < 8; i++)
        {
            int x = (int)transform.position.x + i;
            int z = (int)transform.position.z + i;

            if (x >= 0 && x < 8 && z >= 0 && z < 8)
            {
                if (MazeManager.mapArray[x, z] == 0)
                {
                    availableMovesArray[x, z] = 1;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break; 
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int x = (int)transform.position.x + i;
            int z = (int)transform.position.z - i;

            if (x >= 0 && x < 8 && z >= 0 && z < 8)
            {
                if (MazeManager.mapArray[x, z] == 0)
                {
                    availableMovesArray[x, z] = 1;
                }
                else
                {
                    break; 
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int x = (int)transform.position.x - i;
            int z = (int)transform.position.z + i;

            if (x >= 0 && x < 8 && z >= 0 && z < 8)
            {
                if (MazeManager.mapArray[x, z] == 0)
                {
                    availableMovesArray[x, z] = 1;
                }
                else
                {
                    break; 
                }
            }
            else
            {
                break; 
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int x = (int)transform.position.x - i;
            int z = (int)transform.position.z - i;

            if (x >= 0 && x < 8 && z >= 0 && z < 8)
            {
                if (MazeManager.mapArray[x, z] == 0)
                {
                    availableMovesArray[x, z] = 1;
                }
                else
                {
                    break; 
                }
            }
            else
            {
                break;
            }
        }

    }

    private void ForHorseMovement()
    {
        int[,] possibleMoves = new int[,]
        {
            {1, 2}, {2, 1}, {2, -1}, {1, -2},
            {-1, -2}, {-2, -1}, {-2, 1}, {-1, 2}
        };

        for (int i = 0; i < 8; i++)
        {
            int newX = (int)transform.position.x + possibleMoves[i, 0];
            int newZ = (int)transform.position.z + possibleMoves[i, 1];

            if (newX >= 0 && newX < MazeManager.mapArray.GetLength(0) &&
                newZ >= 0 && newZ < MazeManager.mapArray.GetLength(1) &&
                MazeManager.mapArray[newX, newZ] == 0)
            {
                availableMovesArray[newX, newZ] = 1;
            }
        }
    }

    private void InstantateAwailableMoves() 
    {
        isShowing = true;
        for (int i = 0; i< availableMovesArray.GetLength(0); i++) 
        {
            for(int j = 0; j< availableMovesArray.GetLength(1); j++) 
            {
                if (availableMovesArray[i,j] == 1) 
                {

                    GameObject Temp = Instantiate(availableMovesPrefab,new Vector3(i, 0.035f, j),Quaternion.identity);
                    availableMovesPrefabStack.Push(Temp);
                }
            }
        }
    }


    private void ClearTheMap() 
    {
        isShowing = false;
        while (availableMovesPrefabStack.Count > 0) 
        { 
            Destroy(availableMovesPrefabStack.Pop());
        }
    }

    public void StartCooldown()
    {
        if (!isOnCooldown)
        {
            isOnCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }

    private void GoToCell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, cellLayer))
            {
                if (availableMovesArray[Mathf.RoundToInt(hit.transform.position.x), Mathf.RoundToInt(hit.transform.position.z)] == 1)
                {

                    Vector3 target = new Vector3(Mathf.RoundToInt(hit.transform.position.x), 1, Mathf.RoundToInt(hit.transform.position.z));

                    while (target.x != transform.position.x || target.z != transform.position.z)
                    {
                        target = new Vector3(Mathf.RoundToInt(hit.transform.position.x), 1, Mathf.RoundToInt(hit.transform.position.z));
                        Vector3 direction = target - transform.position;
                        if (direction.magnitude < 0.1f)
                        {
                            transform.position = target;
                        }
                        else
                        {
                            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f * Time.deltaTime);
                        }
                    }
                    
                    if (target.x == transform.position.x && target.z == transform.position.z)
                    {
                        availableMovesArray = new int[8, 8];
                        isPlayerSelected = false;
                    }

                    if (id == 2)
                    {
                        if (hero.health < hero.HeroStats.health)
                        {
                            hero.health++;
                        }  
                    }

                    StartCooldown();
                    Vector3 timerPosition = new Vector3(transform.position.x, 1.75f, transform.position.z);
                    if (hero.HeroStats.id == 0) { Instantiate(RookCDBar, timerPosition, RookCDBar.transform.rotation); }
                    else if (hero.HeroStats.id == 1) { Instantiate(ElefantCDBar, timerPosition, ElefantCDBar.transform.rotation); }
                    else if (hero.HeroStats.id == 2) { Instantiate(HorseCDBar, timerPosition, HorseCDBar.transform.rotation); }
                    else if (hero.HeroStats.id == 4) { Instantiate(elGuardCDBar, timerPosition, elGuardCDBar.transform.rotation); }

                }
            }
            
        }
    }
}
