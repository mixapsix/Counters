﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Counters.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
