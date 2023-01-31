using EFCoreRelationships.DTOs;

namespace EFCoreRelationships.EmailService
{
    public interface IEmailService
    {
        string SendEmail(RequestDTO request);
    }
}
