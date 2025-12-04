using System.Collections;
using TMPro;
using UnityEngine;
using static Gem;

public class SkullPuzzle : MonoBehaviour, IInteractable
{
    public GameObject gemPrefab;
    public GemColor requiredColor;
    public int solutionDigit;

    public TextMeshPro digitDisplay;
    public Transform gemSlot;

    private bool isSolved = false;

    void Start()
    {
        digitDisplay.alpha = 0;
    }

    public void Interact()
    {
        if (isSolved)
            return;

        if (GemInventory.gemInventory.HasGem(requiredColor))
        {
            GemInventory.gemInventory.RemoveGem(requiredColor);
            Instantiate(gemPrefab, gemSlot.position, gemSlot.rotation);
            Debug.Log("Вставили камень");
            SolvePuzzle();
        }
        else
        {
            Debug.Log($"Нужен {requiredColor} камень");
        }
    }

    private void SolvePuzzle()
    {
        isSolved = true;
        digitDisplay.text = solutionDigit.ToString();
        StartCoroutine(AnimateDigit());
        Debug.Log("Запускаем анимацию");
    }

    private IEnumerator AnimateDigit()
    {
        float duration = 2f;
        float timer = 0;
        Debug.Log("Запуск анимации появления");
        while (timer < duration)
        {
            digitDisplay.alpha = Mathf.Lerp(0, 1, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Окончание");
        timer = 0;
        yield return new WaitForSeconds(1f);
        Debug.Log("Прошла секунда, исчезновение");
        while (timer < duration)
        {
            digitDisplay.alpha = Mathf.Lerp(1, 0, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Окончание");
        timer = 0;
        yield return new WaitForSeconds(1f);
    }
}