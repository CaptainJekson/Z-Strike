using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private CharState State
    {
        get { return (CharState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }        
    }

    public float HandState
    {
        get { return _animator.GetFloat("Hand State"); }
        set { _animator.SetFloat("Hand State", value); }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.PlayerMoves += () => State = CharState.Run;
        _player.PlayerMoves += () => _animator.speed = _player.Velocity;
        _player.PlayerIdles += () => State = CharState.Idle;
        _player.PlayerIdles += () => _animator.speed = 1;
    }

    private void OnDisable()
    {
        _player.PlayerMoves -= () => State = CharState.Run;
        _player.PlayerMoves -= () => _animator.speed = _player.Velocity;
        _player.PlayerIdles -= () => State = CharState.Idle;
        _player.PlayerIdles -= () => _animator.speed = 1;
    }

    enum CharState
    {
        Idle,
        Run,
        Die
    }
}
