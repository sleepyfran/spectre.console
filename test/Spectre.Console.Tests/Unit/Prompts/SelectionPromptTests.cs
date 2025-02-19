namespace Spectre.Console.Tests.Unit;

public sealed class SelectionPromptTests
{
    [Fact]
    public void Should_Not_Throw_When_Selecting_An_Item_With_Escaped_Markup()
    {
        // Given
        var console = new TestConsole();
        console.Profile.Capabilities.Interactive = true;
        console.Input.PushKey(ConsoleKey.Enter);
        var input = "[red]This text will never be red[/]".EscapeMarkup();

        // When
        var prompt = new SelectionPrompt<string>()
                .Title("Select one")
                .AddChoices(input);
        prompt.Show(console);

        // Then
        console.Output.ShouldContain(@"[red]This text will never be red[/]");
    }

    [Fact]
    public void Should_Select_The_First_Leaf_Item()
    {
        // Given
        var console = new TestConsole();
        console.Profile.Capabilities.Interactive = true;
        console.Input.PushKey(ConsoleKey.Enter);

        // When
        var prompt = new SelectionPrompt<string>()
                .Title("Select one")
                .Mode(SelectionMode.Leaf)
                .AddChoiceGroup("Group one", "A", "B")
                .AddChoiceGroup("Group two", "C", "D");
        var selection = prompt.Show(console);

        // Then
        selection.ShouldBe("A");
    }

    [Fact]
    public void Should_Select_The_Last_Leaf_Item_When_Wrapping_Around()
    {
        // Given
        var console = new TestConsole();
        console.Profile.Capabilities.Interactive = true;
        console.Input.PushKey(ConsoleKey.UpArrow);
        console.Input.PushKey(ConsoleKey.Enter);

        // When
        var prompt = new SelectionPrompt<string>()
            .Title("Select one")
            .Mode(SelectionMode.Leaf)
            .WrapAround()
            .AddChoiceGroup("Group one", "A", "B")
            .AddChoiceGroup("Group two", "C", "D");
        var selection = prompt.Show(console);

        // Then
        selection.ShouldBe("D");
    }
}
