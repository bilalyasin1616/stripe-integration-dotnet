using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public partial class UserDTO
    {
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(250)]
        public string Phone { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(350)]
        public string AddressLine1 { get; set; }
        [StringLength(350)]
        public string AddressLine2 { get; set; }
        [StringLength(45)]
        public string State { get; set; }
        [StringLength(10)]
        public string Postal { get; set; }
        [StringLength(2)]
        public string CountryId { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        [StringLength(250)]
        public string Password { get; set; }
        [StringLength(150)]
        public string PasswordResetToken { get; set; }
        public bool HasValidatedEmail { get; set; }
        public bool HasValidPayment { get; set; }
    }
}
