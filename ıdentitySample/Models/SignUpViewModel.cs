using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ıdentitySample.Models
{
    public class SignUpViewModel
    {

        [Required( ErrorMessage ="kullanıcı adı boş bırakılmaz")]
        [MinLength(5, ErrorMessage = "5 karakterden az olamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email  boş bırakılmaz")]
        [EmailAddress(ErrorMessage ="düzgün bir email formatı giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılmaz")]
        [DataType(DataType.Password)]

        //[MinLength(5,ErrorMessage ="5 karakterden az olamaz")]
        //[MaxLength(10,ErrorMessage ="10 karakterden fazla olamaz")]


        [Ignore]
        [StringLength(15,ErrorMessage ="5'den az 15'den fazla olamaz", MinimumLength =3)]
        public string Password { get; set; }
    }
}
