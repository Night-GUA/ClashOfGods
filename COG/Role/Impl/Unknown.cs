using AmongUs.GameOptions;
using COG.Config.Impl;
using COG.Listener;
using UnityEngine;

namespace COG.Role.Impl;

public class Unknown : CustomRole
{
    public Unknown() : base(LanguageConfig.Instance.UnknownName, Color.white, CampType.Unknown, false)
    {
        BaseRoleType = RoleTypes.CrewmateGhost;
        ShortDescription = LanguageConfig.Instance.UnknownDescription;
    }

    public override IListener GetListener()
    {
        return IListener.EmptyListener;
    }

    public override CustomRole NewInstance()
    {
        return new Unknown();
    }
}