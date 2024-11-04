using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Weapon")]
    public class Weapon : ScriptableObject, ICommandAttack
    {
        [SerializeField] private AttackData data;

        [SerializeField] private string animationName;

        [SerializeField] private GameObject weaponPrefab;

        public GameObject weaponInstance;
        
        public AttackData _data => data;
        
        public string _animationName => animationName;
        public GameObject _weaponPrefab => weaponPrefab;


        public void Attack()
        {
            weaponInstance.GetComponent<WeaponHitboxHandler>().PreformHitboxAttack(data._attackDuration, data._damage);
        }


    }
}    
