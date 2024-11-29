﻿using Snake.Base;

namespace Snake.Models
{
    public class WindowModel<TView, TViewModel>
        where TView : VisualElement
        where TViewModel : BaseViewModel, new()
    {
        public required TView View { get; set; }
        public required TViewModel ViewModel { get; set; }
    }
}
