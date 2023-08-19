using System;
using Ultraviolet.Presentation;

namespace UpfGame.Shared.UI.Screens
{
    public sealed class GamePlayViewModel
    {
        public void HandleButtonClicked(DependencyObject element, RoutedEventData data) => Counter++;
        public Int32 Counter { get; set; }
    }
}
