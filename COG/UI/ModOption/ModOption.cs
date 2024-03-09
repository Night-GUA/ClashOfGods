using System;
using System.Collections.Generic;

namespace COG.UI.ModOption;

public class ModOption
{
    public static readonly List<ModOption> Buttons = new();
    public readonly bool DefaultValue;
    public readonly Func<bool> OnClick;
    public readonly string Text;

    public ToggleButtonBehaviour? ToggleButton;

    public ModOption(string text, Func<bool> onClick, bool defaultValue)
    {
        Text = text;
        OnClick = onClick;
        DefaultValue = defaultValue;
    }

    public void Register()
    {
        Buttons.Add(this);
    }
}