﻿using PieShopHRM.Components.Widgets;

namespace PieShopHRM.Components.Pages
{
    public partial class Home
    {
        public List<Type> Widgets { get; set; } = new List<Type>()
            { typeof(EmployeeCountWidget), typeof(InboxWidget) };
    }
}