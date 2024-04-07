using Gameplay;
using Gameplay.World;
using GameStates;
using Schemas;
using Utility;
using Loadout = Schemas.Loadout;

/// <summary>
/// This class acts as a ServiceLocator root and can be statically accessed via ServiceLocator.Instance.
/// It is what bootstraps the game scene.
/// </summary>

public class ServiceLocator : SingletonMonoBehaviour
{
    public static ServiceLocator Instance => ((ServiceLocator)InternalInstance);

    // WorldSettings and Config of the run (Move this stuff somewhere else later)
    // 
    public WorldSettings WorldSettings;
    public Loadout LoadoutSettings;
    public Schema.ProductionStatus MininmumStatus;
    
    // MonoBehavior backed systems
    public World World;

    // Non-MonoBehavior backed systems
    public Schemas.Schemas Schemas = new Schemas.Schemas();
    public Gameplay.Loadout Loadout = new Gameplay.Loadout();
    public Bank Bank = new Bank();
    public UIDisplayProcessor UIDisplayProcessor;
    
    //  todo: go in some gamemanager
    public StateMachine StateMachine = new StateMachine();
    
    protected override void Awake()
    {
        base.Awake();
        
        Schemas.Initialize(MininmumStatus);
        World.Initialize(WorldSettings);
        Loadout.Initialize(LoadoutSettings);
        Bank.Initialize();
    }

    public void Start()
    {
        StateMachine.ChangeState(new StateSetup());
    }

    public void Update()
    {
        StateMachine.Update();
    }

    public void RegisterUIDisplayProcessor(UIDisplayProcessor processor)
    {
        UIDisplayProcessor = processor;
    }
}
