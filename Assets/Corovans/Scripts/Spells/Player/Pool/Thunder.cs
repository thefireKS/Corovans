using UnityEngine;

namespace Corovans.Scripts.Spells.Player.Pool
{
    public class Thunder : Spell
    {
        [SerializeField] private GameObject thunderObject;
        
        public override void UseSpell()
        {
            Instantiate(thunderObject, GetCursorPositionInWorld(), Quaternion.identity);
        }
        
        public static Vector3 GetCursorPositionInWorld()
        {
            // Получаем позицию курсора в экранных координатах
            Vector3 cursorPositionScreen = Input.mousePosition;

            // Преобразуем экранные координаты в луч в мировых координатах
            Ray ray = Camera.main.ScreenPointToRay(cursorPositionScreen);

            // Пересекаем луч с плоскостью Z = 0 (или другой плоскостью по вашему выбору)
            Plane plane = new Plane(Vector3.forward, Vector3.zero);
            float distance;
            plane.Raycast(ray, out distance);

            // Получаем позицию пересечения луча с плоскостью
            Vector3 cursorPositionWorld = ray.GetPoint(distance);

            return cursorPositionWorld;
        }
    }
}
