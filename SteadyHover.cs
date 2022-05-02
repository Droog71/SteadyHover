public class SteadyHover : FortressCraftMod
{
    private bool OverrideHover(LocalPlayerScript player)
    {
        return !player.mbGrounded && player.mbJetPack && player.mbJetPackHoverMode && SurvivalPowerPanel.mrSuitPower > 1;
    }

    public void Update()
    {
        if (WorldScript.instance != null)
        {
            if (WorldScript.instance.mWorldData != null)
            {
                LocalPlayerScript player = WorldScript.instance.localPlayerInstance;
                if (player != null)
                {
                    if (OverrideHover(player))
                    {
                        player.mVelocity.y = 0.0f;
                        player.mrHoverAdjust = 0.0f;
                        player.mrHoverY = player.mPosition.y;
                        WorldScript.instance.mWorldData.mrGravity = 0.0f;
                    }
                    else
                    {
                        WorldScript.instance.mWorldData.mrGravity = 0.3f;
                    }
                }
            }
        }
    }

    public override ModRegistrationData Register()
    {
        return new ModRegistrationData();
    }
}
