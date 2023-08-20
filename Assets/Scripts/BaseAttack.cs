using System.Collections;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private float _timer = 0f;
    private bool _animationInProgress = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _spriteRenderer.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            _timer += Time.deltaTime;

            if (_timer >= 2.5f)
            {
                if (!_animationInProgress)
                {
                    _spriteRenderer.enabled = true;
                    _animator.SetTrigger("Attack");
                    _animationInProgress = true;

                    // Ждем завершения анимации
                    yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
                }
                else
                {
                    _spriteRenderer.enabled = false;
                    _animationInProgress = false;
                    _timer = 0f;
                }
            }

            Debug.Log(_timer);

            yield return null;
        }
    }
}

