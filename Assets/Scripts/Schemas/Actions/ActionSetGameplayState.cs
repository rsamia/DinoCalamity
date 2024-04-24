using Gameplay;
using GameStates;
using UnityEngine;

namespace Schemas.Actions
{
    /// <summary>
    /// Use this action to force a game state.
    /// </summary>
    [CreateAssetMenu(menuName = "Action/ActionSetGameplayState")]  
    public class ActionSetGameplayState : Action
    {
        /// TODO: Support all states? For now, Loss/Win
        public enum State
        {
            Loss,
            Win
        }

        public State DesiredState = State.Loss;
        
        public override void Invoke(Invoker.Context context)
        {
            switch (DesiredState)
            {
                case State.Loss:
                    ServiceLocator.Instance.GameManager.StateMachine.ChangeState(new StateLoss());
                    break;
                case State.Win:
                    ServiceLocator.Instance.GameManager.StateMachine.ChangeState(new StateWin());
                    break;
            }
        }
    }
}
