namespace Spectre.Console;

internal sealed class ListPromptConstants
{
    public const string Arrow = ">";
    public const string Checkbox = "[[ ]]";
    public const string SelectedCheckbox = "[[[blue]X[/]]]";
    public const string GroupSelectedCheckbox = "[[[grey]X[/]]]";
    public const string InstructionsMarkup = "[grey](Press <space> to select, <enter> to accept)[/]";
    public const string MoreChoicesMarkup = "[grey](Move up and down to reveal more choices)[/]";
    public const string CancelPlaceholderMarkup = "[grey](Press Esc to cancel selection)[/]";
    public const string SearchPlaceholderMarkup = "[grey](Type to search)[/]";
}