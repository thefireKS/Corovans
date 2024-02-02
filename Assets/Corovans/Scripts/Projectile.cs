#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Corovans.Scripts
{
    [ExecuteInEditMode]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private string targetTag;
        [SerializeField] private int damage;

        #region TagSelector

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying && !PrefabUtility.IsPartOfPrefabAsset(gameObject))
            {
                // Получаем массив существующих тегов
                string[] tagArray = UnityEditorInternal.InternalEditorUtility.tags;

                // Проверяем, есть ли выбранный тег среди существующих
                if (System.Array.IndexOf(tagArray, targetTag) == -1)
                {
                    // Если тега нет среди существующих, устанавливаем первый тег из массива (по умолчанию)
                    targetTag = tagArray.Length > 0 ? tagArray[0] : "Untagged";
                }
            }
#endif
        }

        [CustomEditor(typeof(Projectile))]
        private class ProjectileEditor : Editor
        {
            private SerializedProperty speedProp;
            private SerializedProperty targetTagProp;
            private SerializedProperty damageProp;

            private void OnEnable()
            {
                speedProp = serializedObject.FindProperty("speed");
                targetTagProp = serializedObject.FindProperty("targetTag");
                damageProp = serializedObject.FindProperty("damage");
            }

            public override void OnInspectorGUI()
            {
                serializedObject.Update();

                Projectile projectile = (Projectile)target;

                // Получаем массив существующих тегов
                string[] tagArray = UnityEditorInternal.InternalEditorUtility.tags;

                // Индекс выбранного тега
                int selectedIndex = System.Array.IndexOf(tagArray, projectile.targetTag);

                // Отображаем выпадающий список тегов
                EditorGUI.BeginChangeCheck();
                selectedIndex = EditorGUILayout.Popup("Target Tag", selectedIndex, tagArray);
                if (EditorGUI.EndChangeCheck())
                {
                    // Устанавливаем выбранный тег из массива
                    targetTagProp.stringValue = tagArray[selectedIndex];
                    // Применяем изменения
                    serializedObject.ApplyModifiedProperties();
                }

                // Отображаем остальные параметры без списка
                EditorGUILayout.PropertyField(speedProp, new GUIContent("Speed"));
                EditorGUILayout.PropertyField(damageProp, new GUIContent("Damage"));

                // Применяем изменения
                serializedObject.ApplyModifiedProperties();
            }
        }
        #endregion

        private void Update()
        {
            if (Application.isPlaying)
            {
                transform.position += transform.right * (speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(targetTag))
            {
                other.GetComponent<IDamageable>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
