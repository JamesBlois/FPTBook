using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }

    }
}
