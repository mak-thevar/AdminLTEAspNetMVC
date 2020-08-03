using AspMVCAdminLTE.Entity.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMVCAdminLTE.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [Index("IX_MobileNumber", IsUnique = true)]
        [MaxLength(12)]
        public string Mobile { get; set; }

        [Required]
        [Index("IX_Username", IsUnique = true)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsMobileVerified { get; set; } = false;

        public DateTime? DateOfBirth { get; set; }

        [Index("IX_Email", IsUnique = true)]
        [MaxLength(100)]
        public string Email { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        public bool IsEmailVerified { get; set; } = false;

        public string ProfilePic { get; set; }

        [EnumDataType(typeof(UserRole))]
        public UserRole UserRole { get; internal set; }
    }
}