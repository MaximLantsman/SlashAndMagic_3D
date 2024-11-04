using System;
using UnityEngine;

namespace WeaponSystem
{
    [Serializable]
    public class AttackData
    {
        [SerializeField]private new string name;
    
        [SerializeField]private float attackDuration;
        [SerializeField]private float attackCooldown;
    
        [SerializeField]private int damage;
        
        public string _name=>name;
    
        public float _attackDuration=>attackDuration;
        public float _attackCooldown=>attackCooldown;
    
        public int _damage=>damage;
    }
}

