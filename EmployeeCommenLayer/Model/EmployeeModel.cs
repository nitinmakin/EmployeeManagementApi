using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeCommenLayer.Model
{
   public class EmployeeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$", ErrorMessage = "Please enter a valid first name ")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$", ErrorMessage = "Please enter a valid Last name ")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
