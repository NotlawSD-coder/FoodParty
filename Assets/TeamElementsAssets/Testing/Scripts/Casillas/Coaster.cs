using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;

public class Coaster : MonoBehaviour
{
    public List<Coaster> next = new List<Coaster>();
    public List<BoardEntity> players = new List<BoardEntity>();

    public static Coaster initialCoaster;

    public List<Vector3> waitZones = new List<Vector3>();
    private Dictionary<Vector3, BoardEntity> waitZonesState = new Dictionary<Vector3, BoardEntity>();

    public int coasterId { get; private set; }

    public bool isInitial
    {
        get
        {
            return type == CoasterType.Initial;
        }
    }

    public enum CoasterType
    {
        Normal,
        Initial,
        Finish,
        Safe,
        Teleport,
        Shop/*,
        Bonus,
        Trap*/
    }

    public CoasterType type;

    public bool canRequestStop;
    private bool canForceStop
    {
        get
        {
            return true; // WIP
        }
    }

    #region Awake/Start/Update
    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {

    }
    #endregion

    public void Initialize()
    {
        if (isInitial)
        {
            if (initialCoaster != null)
            {
                Debug.LogWarning($"Warning. There can be only one initial coaster. {name} will now be disabled.");
                enabled = false;
                return;
            }
            initialCoaster = this;
        }
        CreateWaitZones(GameManager.maxPlayers);
        //GameObjectUtility.SetStaticEditorFlags(gameObject, StaticEditorFlags.NavigationStatic);
        NavMeshSurface nms = gameObject.AddComponent<NavMeshSurface>();
        nms.collectObjects = CollectObjects.Children;
    }

    // Realizar su funci�n.
    public virtual void Interact()
    {

    }

    private void CreateWaitZones(int amount)
    {
        int subdivisionAngle = 360 / amount;
        for(int i = 0; i < amount; i++)
        {
            GameObject waitZone = new GameObject("Wait Zone");
            waitZone.transform.position = transform.position;
            waitZone.transform.eulerAngles = new Vector3(0f, (i + 1) * subdivisionAngle, 0f);
            waitZone.transform.position += waitZone.transform.forward.normalized * (transform.localScale.magnitude / 2.5f);
            waitZone.transform.parent = transform;
            waitZones.Add(waitZone.transform.position);
            waitZonesState.Add(waitZone.transform.position, null);
        }
    }

    public List<Vector3> GetAvailableWaitZones()
    {
        //Debug.Log("===========START FINDING WAIT ZONES============");
        List<Vector3> result = new List<Vector3>();
        foreach(Vector3 waitZone in waitZones)
        {
            if(waitZonesState.ContainsKey(waitZone) && waitZonesState[waitZone] == null)
            {
                result.Add(waitZone);
            }
        }
        /*
        Debug.Log("Final result: Found " + result.Count);
        Debug.Log("===========END FINDING WAIT ZONES============");
        */
        return result;
    }

    public void SetWaitZoneState(Vector3 waitZone, BoardEntity entity)
    {
        //Debug.Log("Requested zone to update: " + waitZone);
        //Debug.Log("Entity value as parameter: " + entity);
        //Debug.Log("Is wait zone on the dictionary? " + waitZonesState.ContainsKey(waitZone));
        //Debug.Log("List of all value in the dictionary:");
        foreach(KeyValuePair<Vector3, BoardEntity> kp in waitZonesState)
        {
            //Debug.Log("Key: " + kp.Key + " | Value: " + kp.Value);
        }
        waitZonesState[waitZone] = entity;
        //Debug.Log("Is wait zone still on the dictionary? " + waitZonesState.ContainsKey(waitZone));
    }

    // Movimiento en casillas.
    protected event Action<BoardEntity, Vector3> onPlayerEnter;
    public void playerEnter(BoardEntity player, Vector3 position)
    {
        //Debug.Log("Player entered the coaster!");
        SetWaitZoneState(position, player);
        if(onPlayerEnter != null)
        {
            onPlayerEnter(player, position);
        }
    }

    protected event Action<BoardEntity> onPlayerStop;
    public void playerStop(BoardEntity player)
    {
        //Debug.Log("Player stopped on coaster!");
        Interact();
        if(onPlayerStop != null)
        {
            onPlayerStop(player);
        }
    }

    protected event Action<BoardEntity> onPlayerLeave;
    public void playerLeave(BoardEntity entity)
    {
        //Debug.Log("Player left the coaster!");

        int i = 0;
        while(i < waitZonesState.Count)
        {
            if(waitZonesState[waitZones[i]] == entity)
            {
                waitZonesState[waitZones[i]] = null;
                i = waitZonesState.Count;
            } else
            {
                i++;
            }
        }

        /*
        foreach(KeyValuePair<Vector3, BoardEntity> kP in waitZonesState)
        {
            if(kP.Value == entity)
            {
                waitZonesState[kP.Key] = null;
            }
        }
        */

        //SetWaitZoneState(position, null);
        if (onPlayerLeave != null)
        {
            onPlayerLeave(entity);
        }
    }

    // Forzar la detenci�n del player.
    public void ForceStop(BoardEntity player)
    {
        player.ForceStop();
    }

    // Activarse o desactivarse.
    public bool isCoasterEnabled = true;
    public void ToggleCoasterState()
    {
        isCoasterEnabled = !isCoasterEnabled;
    }

    public void SetCoasterState(bool enabled)
    {
        isCoasterEnabled = enabled;
    }

    /* Que cosas puede hacer una casilla:
     * 
     * Realizar su funci�n.
     * Dar paso a otras casillas.
     * Forzar la detenci�n del player.
     * Almacenar ingredientes.
     * Poner trampas.
     * Activarse o desactivarse.
     */
}