using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static JobFinder.Infrastructure.Constants.ValidationConstants;

namespace JobFinder.Infrastructure.Data.Models
{
    [Comment("Messages table")]
    public class Message
    {
        [Key]
        [Comment("Message identifier")]
        public int Id { get; set; }

        [Required]
        [MinLength(MessageConstants.ContentMinLength)]
        [MaxLength(MessageConstants.ContentMaxLength)]
        [Comment("Message content")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("Time message was sent")]
        public DateTime SentAt { get; set; }

        [Required]
        public string SenderId { get; set; } = null!;

        [Required]
        public string ReceiverId { get; set; } = null!;

        [ForeignKey(nameof(SenderId))]
        public AppUser Sender { get; set; } = null!;

        [ForeignKey(nameof(ReceiverId))]
        public AppUser Receiver { get; set; } = null!;
    }
}
