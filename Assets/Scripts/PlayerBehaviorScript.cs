using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    #region Object Set-up

    public GameObject myPlayer;
    public Camera myFPSCamera;
    [SerializeField] GameObject parentGameObject;
    [SerializeField] Rigidbody myPlayerRB;

    #endregion

    #region Player Movement Variables

    [SerializeField] float playerMoveSpeed;
    [SerializeField] float playerRotationSpeed;

    Quaternion cameraRotation;

    Vector3 playerMoveVert;
    Vector3 playerMoveHori;

    float vertAxis;
    float horiAxis;

    #endregion

    #region Raycast Shooting

    bool bodiesVisible;
    RaycastHit hitscanTarget;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        bodiesVisible = true;
        myPlayerRB = myPlayer.GetComponent<Rigidbody>();
        playerMoveSpeed = 200;
        playerRotationSpeed = 100;

        //Disable mouse cursor at start of play.
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetCursorState();
        CameraRotateUpdate();
        Shoot();
        MoveInput();
        EnemyVisibility();
    }

    #region Move Input
    void MoveInput()
    {
        /*vertAxis = Input.GetAxis("Vertical");
        horiAxis = Input.GetAxis("Horizontal");

        playerMoveVert = new Vector3(0, 0, vertAxis);
        playerMoveHori = new Vector3(horiAxis, 0, 0);*/

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Moving forward.");
            myPlayerRB.velocity = transform.forward * playerMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Moving backward.");
            myPlayerRB.velocity = -transform.forward * playerMoveSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Moving on the horizontal axis.");
            myPlayerRB.velocity = -transform.right * playerMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            myPlayerRB.velocity = transform.right * playerMoveSpeed * Time.deltaTime;
        }
    }
    #endregion

    #region Camera Rotate Update
    void CameraRotateUpdate()
    {
        myFPSCamera.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -1, 0, 0) * Time.deltaTime * playerRotationSpeed);
        myPlayer.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * playerRotationSpeed);
    }
    #endregion

    #region Shoot Function
    void Shoot()
    {
        if (Input.GetMouseButton(0) && bodiesVisible == true)
        {
            Physics.Raycast(myFPSCamera.transform.position, myFPSCamera.transform.forward, out hitscanTarget, 500);

            parentGameObject = hitscanTarget.transform.parent.gameObject;

            if (hitscanTarget.transform.tag == "EnemyHurtbox")
            {
                RandomSpawn.DestroyObjectInList(parentGameObject);
                Debug.Log("HIT!");
            }
            else if (hitscanTarget.transform.tag == "EnemyBody")
            {
                Debug.Log("He's not actually there!");
            }
            else
            {
                Debug.Log("Where are you shooting?");
            }
        }
        else
        {
            Debug.Log("You can't shoot while you can't see their bodies!");
        }
    }
    #endregion

    #region Cursor State

    void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Hide cursor when locking
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    #endregion

    #region Enemy Visibility

    void EnemyVisibility()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RandomSpawn.VisibleBodies();
            bodiesVisible = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            RandomSpawn.VisibleHurtboxes();
            bodiesVisible = false;
        }
    }
    #endregion
}
