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
            Instantiate(gemPrefab, gemSlot);
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
    }

    private IEnumerator AnimateDigit()
    {
        float duration = 2f;
        float timer = 0;

        while (timer < duration)
        {
            digitDisplay.alpha = Mathf.Lerp(0, 1, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0;
        yield return new WaitForSeconds(1f);

        while (timer < duration)
        {
            digitDisplay.alpha = Mathf.Lerp(1, 0, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0;
        yield return new WaitForSeconds(1f);
    }
}