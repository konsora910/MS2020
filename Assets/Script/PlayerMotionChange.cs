//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMotionChange : MonoBehaviour
//{
//    //PlayerAnimation
//    private Animator animator;                              //  プレイヤーがキー入力によってモーションが変化する
//    [SerializeField] private PlayerController _PlayerModeScript;   //  プレイヤー
//    //PlayerWalkingEffect
//    private ParticleSystem particle;
    

//    // Start is called before the first frame update
//    void Start()
//    {
//        animator = GetComponent<Animator>();

//        particle = this.GetComponent<ParticleSystem>();
//        particle.Stop();
//    }

//    /// <summary>
//    /// モーションを変更
//    /// </summary>
//    // モーションをモードによって切り替える
//    void MotionChange()
//    {
//        switch (_PlayerModeScript.CurrentMode)
//        {
//            case PlayerController.Mode.Boil:
//                break;
//            case PlayerController.Mode.Cut:
//                break;
//            case PlayerController.Mode.Fry:
//                break;
//            case PlayerController.Mode.Hold:
//                break;
//            case PlayerController.Mode.Set:
//                break;
//            case PlayerController.Mode.Stay:
//                animator.SetBool("is_running", false); // Animatorタブ上の遷移条件
//                particle.Stop();
//                break;
//            case PlayerController.Mode.Walk:
//                animator.SetBool("is_running", true); // Animatorタブ上の遷移条件
//                particle.Play();
//                break;
//            default:
//                break;
//        }
//    }
//}
