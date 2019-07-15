using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı adı"), Required(ErrorMessage ="{0} alanı boş geçilemez.")]
        public string kullaniciAdi { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."),DataType(DataType.Password)]
        public string sifre { get; set; }
    }
}