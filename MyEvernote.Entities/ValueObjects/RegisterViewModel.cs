using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı adı"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(25,ErrorMessage ="{0} {1} karakterden fazla olamaz")]
        public string kullaniciAdi { get; set; }

        [DisplayName("E-posta"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            EmailAddress(ErrorMessage ="{0} alanı bir eposta olmalıdır."),
            StringLength(25, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
        public string ePosta { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            DataType(DataType.Password), 
            StringLength(25, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
        public string sifre { get; set; }

        [DisplayName("Şifre(Tekrar)"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} {1} karakterden fazla olamaz"),
            Compare("sifre",ErrorMessage ="{0} ile {1} uyuşmuyor.")]
        public string sifreTekrar { get; set; }
    }
}