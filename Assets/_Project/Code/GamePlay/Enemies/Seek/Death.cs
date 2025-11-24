using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class Death
{
    private GameObject _enemy;
    private SpriteRenderer _spriteRenderer;

    public Death(GameObject enemy, SpriteRenderer spriteRenderer)
    {
        this._enemy = enemy;
        this._spriteRenderer = spriteRenderer;
    }
    public void Die()
    {
        _enemy.SetActive(false);
    }
    public void DropItems()
    {

    }
    IEnumerator DeathEffect()
    {
        yield return new WaitForSeconds(2f);
        _enemy.SetActive(false);
    }
    IEnumerator FadeSprite()
    {
        float time = 0f;
        Color c = _spriteRenderer.color;

        // FADE IN – se vuelve negro visible
        while (time < 1.5f)
        {
            float t = time / 1.5f;
            _spriteRenderer.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, t));
            time += Time.deltaTime;
            yield return null;
        }
        _spriteRenderer.color = new Color(0f, 0f, 0f, 1f);

        // Espera 2 segundos
        yield return new WaitForSeconds(2f);

        // FADE OUT – se vuelve transparente
        time = 0f;
        while (time < 1.5f)
        {
            float t = time / 1.5f;
            _spriteRenderer.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, t));
            time += Time.deltaTime;
            yield return null;
        }
        _spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
    }
}
