using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public Stats baseStats, currStats;
    public float MovementSpeed;
    public List<StatusEffect> Effects;

    public UnityEvent HPChangedEvent, GotHitEvent, ObjectDiedEvent, OnSpawnEvent, OnDespawnEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Init()
    { }

    public virtual void HPChanged()
    { }

    public virtual void Spawn(Transform point)
    { }

    public virtual void GetHit()
    { }

    public virtual void Die()
    { }

    public virtual void AddStatus(StatusEffect eff)
    { }

    public virtual void CommitStatus()
    { }




}
