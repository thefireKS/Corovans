namespace Corovans.Scripts
{
    public interface IDamageable
    {
        void TakeDamage(int damageAmount);
        void Die();
    }
}