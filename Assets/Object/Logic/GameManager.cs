using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] AudioSource audioSource;
    public IReadOnlyReactiveProperty<bool> State => _state;

    private readonly ReactiveProperty<bool> _state = new ReactiveProperty<bool>(false);

    void Start()
    {
        GameStart().Forget();
    }

    private async UniTaskVoid GameStart(){
        //ゲーム中
        await UniTask.WaitWhile(() => audioSource.isPlaying);
        // _state.Value = false;
        _state.Value = true;
        
    }
}
