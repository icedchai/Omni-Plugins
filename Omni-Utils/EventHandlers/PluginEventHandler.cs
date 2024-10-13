
using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Item;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player; 

namespace Omni_Utils.EventHandlers
{
    public class PluginEventHandler
    {
        public void OnPlayerJump(JumpingEventArgs e)
        {
            if (e.Player.IsHuman & e.Player.IsUsingStamina)
            { 
                if (e.Player.IsEffectActive<Invigorated>()||e.Player.IsEffectActive<Scp207>())
                {
                    Log.Debug($"{e.Player.Nickname}/{e.Player.UserId} dodged stamina");
                    return;
                }
                else
                {
                    Log.Debug($"{e.Player.Nickname}/{e.Player.UserId} used jump stamina");
                    e.Player.Stamina -= (OmniUtilsPlugin.pluginInstance.Config.StaminaUseOnJump * 0.01f);
                }
            }
        }




    }
}
