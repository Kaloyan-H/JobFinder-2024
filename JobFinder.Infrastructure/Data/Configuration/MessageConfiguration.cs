using JobFinder.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Data.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public MessageConfiguration() { }

        public MessageConfiguration(Message[] initialMessages)
        {
            InitialMessages = initialMessages;
        }

        public Message[] InitialMessages { get; init; } = new Message[0];

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasData(InitialMessages);
        }
    }
}
