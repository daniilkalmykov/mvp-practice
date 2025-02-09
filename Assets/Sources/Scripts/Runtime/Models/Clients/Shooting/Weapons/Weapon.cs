using Sources.Scripts.Runtime.Models.Clients.Detectables;
using Sources.Scripts.Runtime.Models.Clients.Health;
using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Shooting.Weapons
{
    public abstract class Weapon
    {
        private readonly float _delay;
        
        private float _currentDelay;
        
        protected Weapon(int damage, float delay)
        {
            Damage = damage;
            _delay = delay;
        }

        protected int Damage { get; }

        public void OnUpdated()
        {
            _currentDelay += Time.deltaTime;
        }

        public bool CanShoot()
        {
            return _currentDelay > _delay;
        }
        
        public void Shoot(Detectable<IDamageable> detectable)
        {
            _currentDelay = 0;

            Hit(detectable);
        }

        protected abstract void Hit(Detectable<IDamageable> detectable);
    }
}