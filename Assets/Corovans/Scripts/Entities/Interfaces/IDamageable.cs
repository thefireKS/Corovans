namespace Corovans.Scripts.Entities.Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(int damageAmount);
        void Die();
    }
}