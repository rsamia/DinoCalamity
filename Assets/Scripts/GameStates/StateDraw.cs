using Utility;

namespace GameStates
{
    public class StateDraw : IState
    {
        public void Enter()
        {
            ServiceLocator.Instance.Loadout.DrawUntilFull();
        }

        public void Update()
        {
            // On first update, go into StatePlay
            ServiceLocator.Instance.StateMachine.ChangeState(new StatePlay());
        }

        public void Exit()
        {
        }
    }
}
