using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject originalCube;
    public Transform cubeParent;
    public bool gamepaused;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // int time = 0;
        // while(time < 10){
        //     var cubeClone = Instantiate(originalCube, new Vector3(time, 1, 5), Quaternion.identity);
        //     cubeClone.transform.parent = cubeParent;
        //     time = time + 1;            
        // }

    }
}
