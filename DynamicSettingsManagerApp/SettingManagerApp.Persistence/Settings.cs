﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Persistence
{
    public static class Settings
    {
        public static string ConnString = "Server=.;Database=AppConfigDB;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=True;";

        public static string ConnStringServiceProduct = "Server=.;Database=ProductDB;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=True;";
    }
}
