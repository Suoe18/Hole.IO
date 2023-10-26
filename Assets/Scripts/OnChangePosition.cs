using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnChangePosition : MonoBehaviour
{
    public static OnChangePosition onChangePositionInstance;

    [SerializeField] PolygonCollider2D hole2DCollider;
    [SerializeField] PolygonCollider2D ground2DCollider;
    [SerializeField] MeshCollider generatedMeshCollider;
    [SerializeField] Collider groundCollider;


    [SerializeField] float initialScale = 0.5f;    
    Mesh generatedMesh;

    [SerializeField] Transform cameraTransformReference;
    public float holeSpeed = 1;
    public float holeSmoothTime = 0.1f;
    float holeTurnSmoothVelocity;

    [SerializeField] float holeXMovementLimit;
    [SerializeField] float holeZMovementLimit;
    [SerializeField] float limitCounter = 0.2f;

    public GameOverScript gameOverInstance;
    

    private void Start()
    {
        onChangePositionInstance = this;

        GameObject[] allGameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach(var go in allGameObjects)
        {
            if(go.layer == LayerMask.NameToLayer("PointObjects"))
            {
                Physics.IgnoreCollision(go.GetComponent<Collider>(), generatedMeshCollider, true);
            }
        }
    }

    private void Update()
    {                     
        if(!GameTimerScript.gameTimerInstance.gameIsDone)
        {
            MovementLimitation();
            HoleMovement();
        }
        else
        {
            GameOver();
        }
           
    }

    private void FixedUpdate()
    {
        if(transform.hasChanged == true)
        {
            transform.hasChanged = false;
            hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            hole2DCollider.transform.localScale = transform.localScale * initialScale;
            
            CreateHole2D();
            CreateMeshCollider3D();
        }                
    }

    public IEnumerator holeScale()
    {
        Vector3 StartScale = transform.localScale;
        Vector3 EndScale = StartScale * 2.25f;

        float t = 0;
        while (t <= 0.4f)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(StartScale, EndScale, t);
            yield return null;
        }

        holeXMovementLimit -= limitCounter;
        holeZMovementLimit -= limitCounter;
        limitCounter += 0.4f;
    }

    private void HoleMovement()
    {                
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransformReference.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref holeTurnSmoothVelocity, holeSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movingDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += movingDirection * holeSpeed * Time.deltaTime;
        }             
    }
    private void MovementLimitation()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, -holeXMovementLimit, holeXMovementLimit),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -holeZMovementLimit, holeZMovementLimit)
        );
            
    }
    private void CreateHole2D()
    {
        Vector2[] pointPositions = hole2DCollider.GetPath(0);

        for(int i = 0; i < pointPositions.Length; i++)
        {
            pointPositions[i] = hole2DCollider.transform.TransformPoint(pointPositions[i]);
        }

        ground2DCollider.pathCount = 2;
        ground2DCollider.SetPath(1, pointPositions);
    }
    private void CreateMeshCollider3D()
    {
        if (generatedMesh != null) Destroy(generatedMesh);
        generatedMesh = ground2DCollider.CreateMesh(true, true);
        generatedMeshCollider.sharedMesh = generatedMesh;

    }

    private void GameOver()
    {
        gameOverInstance.Setup(UIScript.uiScriptInstance.scorePoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(other, groundCollider, true);
        Physics.IgnoreCollision(other, generatedMeshCollider, false);
    }
    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(other, groundCollider, false);
        Physics.IgnoreCollision(other, generatedMeshCollider, true);
    }
}
