using Volo.Abp.Settings;

namespace Nm.Settings
{
    public class NmSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(NmSettings.MySetting1));
        }
    }
}
