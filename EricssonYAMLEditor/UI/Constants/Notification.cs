
namespace EricssonYAMLEditor.UI.Constants
{
    struct Notification
    {
        public struct Constraints
        {
            public const string Title = "Constraints";
            public const string Message =
@"* Content of list items is not visible from parent nodes.
* No new property can be created. Only new list item addition is provided.
* New list item addition is provided for properties that has at least one item.
* No textbox is rendered for properties that has no value.";
        }
    }
}
