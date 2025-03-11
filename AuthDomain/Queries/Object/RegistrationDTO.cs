﻿using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries.Object
{
    public class RegistrationDTO :IQuery
    {
        [Display(Name ="Логин")]
        [Required(ErrorMessage ="Заполните поле для логина")]
        [MinLength(3, ErrorMessage = "Минимум логин 3 буквы")]
        [MaxLength(20, ErrorMessage = "Пароль логин 20 букв")]
        public string Login { get; set; } = null!;

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Заполни пароль")]
        [MinLength(3, ErrorMessage = "Минимум пароль 3 буквы")]
        [MaxLength(20, ErrorMessage = "Пароль максимум 20 букв")]
        public string Password { get; set; } = null!;

        [Compare("Password")]
        [Display(Name = "Пароль еще раз")]
        public string PasswordAgain { get; set; } = null!;

        [Display(Name = "Выбери аватар")]
        public string avatar { get; set; } = null!;
    }
}
