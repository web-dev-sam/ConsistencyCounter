using IPA;
using IPA.Config.Stores;
using IPALogger = IPA.Logging.Logger;

namespace ConsistencyCounter
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static string Name => "ConsistencyCounter";

        [Init]
        public Plugin(IPALogger logger, IPA.Config.Config config)
        {
            Config.Instance = config.Generated<Config>();
            Instance = this;
            Log = logger;
            Log.Info("ConsistencyCounter initialized.");
        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
        #endregion


        [OnEnable]
        public void OnEnable() { }

        [OnDisable]
        public void OnDisable() { }
    }
}
