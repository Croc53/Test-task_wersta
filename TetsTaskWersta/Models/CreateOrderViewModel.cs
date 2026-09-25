using System.ComponentModel.DataAnnotations;

namespace TestTaskWersta.Models;

public class CreateOrderViewModel
{
    [Required(ErrorMessage = "Укажите город отправителя")]
    [StringLength(200, ErrorMessage = "Не более 200 символов")]
    [Display(Name = "Город отправителя")]
    public string SenderCity { get; set; } = string.Empty;




    [Required(ErrorMessage = "Укажите адрес отправителя")]
    [StringLength(500, ErrorMessage = "Не более 500 символов")]
    [Display(Name = "Адрес отправителя")]
    public string SenderAddress { get; set; } = string.Empty;




    [Required(ErrorMessage = "Укажите город получателя")]
    [Display(Name = "Город получателя")]
    public string RecipientCity { get; set; } = string.Empty;




    [Required(ErrorMessage = "Укажите адрес получателя")]
    [Display(Name = "Адрес получателя")]
    public string RecipientAddress { get; set; } = string.Empty;




    [Required(ErrorMessage = "Укажите вес груза")]
    [Range(0.01, 100000, ErrorMessage = "Вес должен быть больше 0")]
    [Display(Name = "Вес груза (кг)")]
    public decimal Weight { get; set; }




    [Required(ErrorMessage = "Укажите дату забора груза")]
    [Display(Name = "Дата забора груза")]
    [DataType(DataType.Date)]
    public DateOnly PickupDate { get; set; }
}