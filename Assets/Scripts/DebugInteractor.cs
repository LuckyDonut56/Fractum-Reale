using UnityEngine;

public class DebugInteractor : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log($"Попал в: {hit.collider.gameObject.name}");

                // Проверяем все компоненты на объекте
                MonoBehaviour[] scripts = hit.collider.GetComponents<MonoBehaviour>();
                foreach (var script in scripts)
                {
                    Debug.Log($"Найден скрипт: {script.GetType().Name}");
                }

                // Пытаемся получить IInteractable
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    Debug.Log("IInteractable найден! Вызываем Interact()");
                    interactable.Interact();
                }
                else
                {
                    Debug.LogWarning("IInteractable НЕ найден!");
                }
            }
        }
    }
}