using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    #region Variable Declaration

    public GameObject myEnemyPrefab;
    public List<GameObject> myEnemyList;
    static List<GameObject> staticEnemyList;

    GameObject newEnemyInstance;

    [SerializeField] float spawnTimer;

    float randX;
    float randZ;

    Vector3 spawnOrigin;
    Vector3 spawnPoint;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        spawnOrigin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        staticEnemyList = myEnemyList;

        randX = Random.Range(-25, 25);
        randZ = Random.Range(-25, 25);

        spawnPoint = spawnOrigin + new Vector3(randX, 0, randZ);

        if (spawnTimer < 360)
        {
            spawnTimer++;
        }
        else
        {
            newEnemyInstance = Instantiate(myEnemyPrefab, spawnPoint, this.transform.rotation);
            myEnemyList.Add(newEnemyInstance);
            spawnTimer = 0;
        }

        myEnemyList = staticEnemyList;
    }

    #region Public Object Destruction Method

    public static void DestroyObjectInList(GameObject destroyedPrefab)
    {
        Destroy(destroyedPrefab);
        staticEnemyList.Remove(destroyedPrefab);
    }

    #endregion

    #region Public Visibility Methods

    public static void VisibleHurtboxes()
    {
        foreach (GameObject enemy in staticEnemyList)
        {
            enemy.GetComponent<MeshRenderer>().enabled = false;
            GameObject childObject = enemy.transform.GetChild(0).gameObject;
            childObject.GetComponent<MeshRenderer>().enabled = true;
        }
        Debug.Log("Enabling Hurtboxes!");
    }

    public static void VisibleBodies()
    {
        foreach (GameObject enemy in staticEnemyList)
        {
            enemy.GetComponent<MeshRenderer>().enabled = true;
            GameObject childObject = enemy.transform.GetChild(0).gameObject;
            childObject.GetComponent<MeshRenderer>().enabled = false;
        }
        Debug.Log("Enabling Bodies!");
    }

    #endregion
}
