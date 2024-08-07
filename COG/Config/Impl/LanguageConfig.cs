using COG.Utils;
using COG.Utils.Coding;
using System;

// ReSharper disable All

namespace COG.Config.Impl;

[ShitCode]
public class LanguageConfig : Config
{
    static LanguageConfig()
    {
        Instance = new LanguageConfig();
        LoadLanguageConfig();
        FirstTimeLoad = false;
    }


    private LanguageConfig() : base(
        "Language",
        DataDirectoryName + "/language.yml",
        new ResourceFile("COG.Resources.InDLL.Config.language.yml")
    )
    {
        SetTranslations();
    }

    private LanguageConfig(string path) : base(
        "Language",
        path
    )
    {
        try
        {
            SetTranslations();
        }
        catch
        {
            // ReSharper disable once Unity.NoNullPropagation
            GameUtils.Popup?.Show("An error occurred when loading language from the disk.");
            Instance = new LanguageConfig();
        }
    }

    private static bool FirstTimeLoad = true;

    public static Action OnLanguageLoaded { get; set;  } = new(() => { });

    public static LanguageConfig Instance { get; private set; }
    public string MakePublicMessage { get; private set; } = null!;

    public string GeneralHeaderTitle { get; private set; } = null!;
    public string SavePreset { get; private set; } = null!;
    public string LoadPreset { get; private set; } = null!;
    public string DebugMode { get; private set; } = null!;
    public string MaxSubRoleNumber { get; private set; } = null!;

    // Unknown
    public string UnknownName { get; private set; } = null!;
    public string UnknownDescription { get; private set; } = null!;

    // Crewmate
    public string CrewmateName { get; private set; } = null!;
    public string CrewmateDescription { get; private set; } = null!;

    public string BaitName { get; private set; } = null!;
    public string BaitDescription { get; private set; } = null!;

    public string SheriffName { get; private set; } = null!;
    public string SheriffDescription { get; private set; } = null!;
    public string SheriffKillCooldown { get; private set; } = null!;

    public string SpyName { get; private set; } = null!;
    public string SpyDescription { get; private set; } = null!;
    public string SpyLongDescText { get; private set; } = null!;

    public string VigilanteName { get; private set; } = null!;
    public string VigilanteDescription { get; private set; } = null!;
    public string VigilanteLongDescText { get; private set; } = null!;

    // Impostor
    public string ImpostorName { get; private set; } = null!;
    public string ImpostorDescription { get; private set; } = null!;

    public string CleanerName { get; private set; } = null!;
    public string CleanerDescription { get; private set; } = null!;
    public string CleanerLongDescText { get; private set; } = null!;
    public string CleanBodyCooldown { get; private set; } = null!;

    public string EraserName { get; private set; } = null!;
    public string EraserDescription { get; private set; } = null!;
    public string EraserLongDescText { get; private set; } = null!;
    public string EraserInitialEraseCd { get; private set; } = null!;
    public string EraserIncreaseCdAfterErasing { get; private set; } = null!;
    public string EraserCanEraseImpostors { get; private set; } = null!;

    // Neutral
    public string JesterName { get; private set; } = null!;
    public string JesterDescription { get; private set; } = null!;

    public string VultureName { get; private set; } = null!;
    public string VultureDescription { get; private set; } = null!;
    public string VultureLongDescText { get; private set; } = null!;
    public string VultureEatCooldown { get; private set; } = null!;
    public string VultureEatenCountToWin { get; private set; } = null!;
    public string VultureHasArrowToBodies { get; private set; } = null!;

    // Sub-roles
    public string GuesserName { get; private set; } = null!;
    public string GuesserDescription { get; private set; } = null!;
    public string GuesserLongDescText { get; private set; } = null!;
    public string GuesserMaxGuessTime { get; private set; } = null!;
    public string GuesserGuessContinuously { get; private set; } = null!;

    public string LighterName { get; private set; } = null!;
    public string LighterDescription { get; private set; } = null!;
    public string LighterLongDescText { get; private set; } = null!;

    public string LoverName { get; private set; } = null!;
    public string LoverDescription { get; private set; } = null!;
    public string LoverCountOptionName { get; private set; } = null!;
    public string LoversDieTogetherOptionName { get; private set; } = null!;
    public string LoverEnablePrivateChat { get; private set; } = null!;

    public string Enable { get; private set; } = null!;
    public string Disable { get; private set; } = null!;
    public string CogOptions { get; private set; } = null!;
    public string LoadCustomLanguage { get; private set; } = null!;
    public string Github { get; private set; } = null!;
    public string UpdateButtonString { get; private set; } = null!;

    public string MaxNumMessage { get; private set; } = null!;
    public string AllowStartMeeting { get; private set; } = null!;
    public string AllowReportDeadBody { get; private set; } = null!;
    public string KillCooldown { get; private set; } = null!;

    public string QQ { get; private set; } = null!;
    public string Discord { get; private set; } = null!;

    public string UnknownCamp { get; private set; } = null!;
    public string ImpostorCamp { get; private set; } = null!;
    public string NeutralCamp { get; private set; } = null!;
    public string CrewmateCamp { get; private set; } = null!;
    public string AddonName { get; private set; } = null!;

    public string UnknownCampDescription { get; private set; } = null!;
    public string ImpostorCampDescription { get; private set; } = null!;
    public string NeutralCampDescription { get; private set; } = null!;
    public string CrewmateCampDescription { get; private set; } = null!;

    public string KillAction { get; private set; } = null!;
    public string CleanAction { get; private set; } = null!;
    public string EraseAction { get; private set; } = null!;
    public string EatAction { get; private set; } = null!;
    public string AnnihilateAction { get; private set; } = null!;
    public string ShowPlayersRolesMessage { get; private set; } = null!;

    public string Alive { get; private set; } = null!;
    public string Disconnected { get; private set; } = null!;
    public string DefaultKillReason { get; private set; } = null!;
    public string UnknownKillReason { get; private set; } = null!;

    public string UnloadModButtonName { get; private set; } = null!;
    public string UnloadModSuccessfulMessage { get; private set; } = null!;
    public string UnloadModInGameErrorMsg { get; private set; } = null!;

    // Update
    public string UpToDate { get; private set; } = null!;
    public string NonCheck { get; private set; } = null!;
    public string FetchedString { get; private set; } = null!;

    public string ImpostorsWinText { get; private set; } = null!;
    public string CrewmatesWinText { get; private set; } = null!;
    public string NeutralsWinText { get; private set; } = null!;

    public string DefaultEjectText { get; private set; } = null!;
    public string AlivePlayerInfo { get; private set; } = null!;
    public string LoverEjectText { get; private set; } = null!;

    public string SystemMessage { get; private set; } = null!;

    private void SetTranslations()
    {
        MakePublicMessage = GetString("lobby.make-public-message");

        GeneralHeaderTitle = LoadPreset = GetString("game-setting.general.title");
        LoadPreset = GetString("game-setting.general.load-preset");
        SavePreset = GetString("game-setting.general.save-preset");
        DebugMode = GetString("game-setting.general.debug-mode");
        MaxSubRoleNumber = GetString("game-setting.general.max-sub-role-number");

        // Unknown
        UnknownName = GetString("role.unknown.name");
        UnknownDescription = GetString("role.unknown.description");

        // Crewmate
        CrewmateName = GetString("role.crewmate.crewmate.name");
        CrewmateDescription = GetString("role.crewmate.crewmate.description");

        BaitName = GetString("role.crewmate.bait.name");
        BaitDescription = GetString("role.crewmate.bait.description");

        SheriffName = GetString("role.crewmate.sheriff.name");
        SheriffDescription = GetString("role.crewmate.sheriff.description");
        SheriffKillCooldown = GetString("role.crewmate.sheriff.kill-cd");

        SpyName = GetString("role.crewmate.spy.name");
        SpyDescription = GetString("role.crewmate.spy.description");
        SpyLongDescText = GetString("role.crewmate.spy.desc-long");

        VigilanteName = GetString("role.crewmate.vigilante.name");
        VigilanteDescription = GetString("role.crewmate.vigilante.description");
        VigilanteLongDescText = GetString("role.crewmate.vigilante.desc-long");

        // Impostors
        ImpostorName = GetString("role.impostor.impostor.name");
        ImpostorDescription = GetString("role.impostor.impostor.description");

        CleanerName = GetString("role.impostor.cleaner.name");
        CleanerDescription = GetString("role.impostor.cleaner.description");
        CleanerLongDescText = GetString("role.impostor.cleaner.desc-long");
        CleanBodyCooldown = GetString("role.impostor.cleaner.clean-cd");

        EraserName = GetString("role.impostor.eraser.name");
        EraserDescription = GetString("role.impostor.eraser.description");
        EraserLongDescText = GetString("role.impostor.eraser.desc-long");
        EraserInitialEraseCd = GetString("role.impostor.eraser.menu.initial-erase-cd");
        EraserIncreaseCdAfterErasing = GetString("role.impostor.eraser.menu.increase-cd-after-erasing");
        EraserCanEraseImpostors = GetString("role.impostor.eraser.menu.can-erase-imps");

        // Neutral
        JesterName = GetString("role.neutral.jester.name");
        JesterDescription = GetString("role.neutral.jester.description");

        VultureName = GetString("role.neutral.vulture.name");
        VultureDescription = GetString("role.neutral.vulture.description");
        VultureLongDescText = GetString("role.neutral.vulture.desc-long");
        VultureEatCooldown = GetString("role.neutral.vulture.eat-cd");
        VultureEatenCountToWin = GetString("role.neutral.vulture.count-to-win");
        VultureHasArrowToBodies = GetString("role.neutral.vulture.has-arrow");

        GuesserDescription = GetString("role.sub-roles.guesser.description");
        GuesserLongDescText = GetString("role.sub-roles.guesser.desc-long");
        GuesserMaxGuessTime = GetString("role.sub-roles.guesser.max-guess-time");
        GuesserGuessContinuously = GetString("role.sub-roles.guesser.guess-continuously");

        LighterName = GetString("role.sub-roles.lighter.name");
        LighterDescription = GetString("role.sub-roles.lighter.description");
        LighterLongDescText = GetString("role.sub-roles.lighter.desc-long");

        LoverName = GetString("role.sub-roles.lover.name");
        LoverDescription = GetString("role.sub-roles.lover.description");
        LoverCountOptionName = GetString("role.sub-roles.lover.count-option");
        LoversDieTogetherOptionName = GetString("role.sub-roles.lover.die-together");
        LoverEnablePrivateChat = GetString("role.sub-roles.lover.private-chat");

        Enable = GetString("option.enable");
        Disable = GetString("option.disable");
        CogOptions = GetString("option.main.cog-options");
        LoadCustomLanguage = GetString("option.main.load-custom-lang");
        Github = GetString("option.main.github");
        QQ = GetString("option.main.qq");
        Discord = GetString("option.main.discord");
        UpdateButtonString = GetString("option.main.update-button-string");

        MaxNumMessage = GetString("role.global.max-num");
        AllowStartMeeting = GetString("role.global.allow-start-meeting");
        AllowReportDeadBody = GetString("role.global.allow-report-body");
        KillCooldown = GetString("role.global.kill-cooldown");

        UnknownCamp = GetString("camp.unknown.name");
        ImpostorCamp = GetString("camp.impostor.name");
        NeutralCamp = GetString("camp.neutral.name");
        CrewmateCamp = GetString("camp.crewmate.name");
        AddonName = GetString("camp.addon");

        UnknownCampDescription = GetString("camp.unknown.description");
        ImpostorCampDescription = GetString("camp.impostor.description");
        NeutralCampDescription = GetString("camp.neutral.description");
        CrewmateCampDescription = GetString("camp.crewmate.description");

        KillAction = GetString("action.kill");
        CleanAction = GetString("action.clean");
        EraseAction = GetString("action.erase-action");
        EatAction = GetString("action.eat-action");
        AnnihilateAction = GetString("action.annihilate");

        ShowPlayersRolesMessage = GetString("game.end.show-players-roles-message");

        Alive = GetString("game.survival-data.alive");
        Disconnected = GetString("game.survival-data.disconnected");
        DefaultKillReason = GetString("game.survival-data.default");
        UnknownKillReason = GetString("game.survival-data.unknown");

        UnloadModButtonName = GetString("option.main.unload-mod.name");
        UnloadModSuccessfulMessage = GetString("option.main.unload-mod.success");
        UnloadModInGameErrorMsg = GetString("option.main.unload-mod.error-in-game");

        UpToDate = GetString("option.main.update.up-to-date");
        NonCheck = GetString("option.main.update.non-check");
        FetchedString = GetString("option.main.update.fetched");

        ImpostorsWinText = GetString("game.end.wins.impostor");
        CrewmatesWinText = GetString("game.end.wins.crewmate");
        NeutralsWinText = GetString("game.end.wins.neutral");

        DefaultEjectText = GetString("game.exile.default");
        AlivePlayerInfo = GetString("game.exile.alive-player-info");
        LoverEjectText = GetString("game.exile.lover-message");

        SystemMessage = GetString("game.chat.system-message");

        if (!FirstTimeLoad) OnLanguageLoaded.GetInvocationList().ForEach(d => d.DynamicInvoke(null));
    }


    private string GetString(string location)
    {
        var toReturn = YamlReader!.GetString(location);
        if (string.IsNullOrWhiteSpace(toReturn))
        {
            Main.Logger.LogError($"Error getting string (location: {location})");
            toReturn = location;
        }

        return toReturn;
    }

    public TextHandler GetHandler(string location) => new(location);

    private static void LoadLanguageConfig()
    {
        Instance.LoadConfig(true);
        Instance = new LanguageConfig();
    }

    internal static void LoadLanguageConfig(string path)
    {
        Instance = new LanguageConfig(path);
    }

    public class TextHandler
    {
        internal TextHandler(string location)
        {
            Location = location;
        }

        public string Location { get; }

        public string GetString(string target)
        {
            return Instance.GetString($"{Location}.{target}");
        }
    }
}