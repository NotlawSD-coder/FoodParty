using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RottenTomato : BoardItem_Base
{
    public BoardItemControls inputActions;

    public ProjectileLauncher<BoardEntity> projectilePrefab;

    public LineRenderer lineRenderer;

    private Scene simulationScene;
    private PhysicsScene physicsScene;

    public float damage = 10f;

    //public float forceMultiplier = 1f;
    public float forceIncreaseRate = 1f;
    public float minForce = 1f;
    public float maxForce = 25f;

    private bool isCharging
    {
        get
        {
            return _isCharging;
        }
        set
        {
            _isCharging = value;
            if (_isCharging)
            {
                StartCoroutine(Charge());
            }
        }
    }
    private bool _isCharging;

    private void Awake()
    {
        inputActions = new BoardItemControls();
        InitializeControls();
        TryGetComponent(out lineRenderer);
        isCharging = false;
        CreateSimulationScene();
    }

    public void InitializeControls()
    {
        inputActions.RottenTomato.Charge.performed += _ => isCharging = true;
        inputActions.RottenTomato.Charge.canceled += _ => isCharging = false;
    }

    public IEnumerator Charge(float updateRate = 0.2f, float maxHoldTime = 10f)
    {
        float i = 0;
        float currentForce = minForce;

        while(isCharging && i < maxHoldTime)
        {
            Debug.Log($"Charging... {i}");
            Simulate(currentForce);
            currentForce += forceIncreaseRate;
            currentForce = Mathf.Clamp(currentForce, minForce, maxForce);
            yield return new WaitForSeconds(updateRate);
            i += Time.deltaTime + updateRate;
        }

        ProjectileLauncher<BoardEntity> projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectileInstance.Launch((transform.forward + transform.up).normalized * currentForce);

        while (projectileInstance.target == null && projectileInstance.lifeTime > 0)
        {
            yield return new WaitForSeconds(updateRate);
        }

        if (projectileInstance.target != null)
        {
            projectileInstance.target.health -= damage;
        }
        Destroy(projectileInstance.gameObject);
        yield return null;
    }

    public void CreateSimulationScene()
    {
        simulationScene = SceneManager.CreateScene("SimulationScene", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();

        foreach (GameObject gO in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (gO.isStatic)
            {
                GameObject objInstance = Instantiate(gO, gO.transform.position, gO.transform.rotation);
                Renderer rndr = objInstance.GetComponent<Renderer>();
                if (rndr != null) rndr.enabled = false;
                SceneManager.MoveGameObjectToScene(objInstance, simulationScene);
            }
        }
    }

    public void Simulate(float force, int frameIterations = 150)
    {
        ProjectileLauncher<BoardEntity> ghostProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(ghostProjectile.gameObject, simulationScene);
        ghostProjectile.Launch((transform.forward + transform.up).normalized * force);

        int i = 0;
        lineRenderer.positionCount = frameIterations;
        while (i < frameIterations)
        {
            if (ghostProjectile.bounces > 0)
            {
                i = frameIterations;
            } else
            {
                physicsScene.Simulate(Time.fixedDeltaTime);
                lineRenderer.SetPosition(i, ghostProjectile.transform.position);
                i++;
            }
        }

        Destroy(ghostProjectile.gameObject);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}