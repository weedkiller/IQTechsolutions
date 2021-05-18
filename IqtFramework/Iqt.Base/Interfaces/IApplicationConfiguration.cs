namespace Iqt.Base.Interfaces
{
    public interface IApplicationConfiguration
    {
        string CompanyName { get; }
        string RegistrationNr { get; }
        string PhoneNr { get; }
        string EmailAddress { get; }

        string AdminEmailAddress { get; }
        string SupportEmailAddress { get; }

        string AbuseEmailAddress { get; }
        string InfoEmailAddress { get; }
        string PhysicalAddress { get; }

        string PhysicalAddressLine1 { get; }

        string PhysicalAddressLine2 { get; }

        string DefaultWebsiteAddress { get; }

        string FacebookUrl { get; }
        string TwitterUrl { get; }
        string LinkedInUrl { get; }
        string YouTubeUrl { get; }
        string PrinterestUrl { get; }
        string InstagramUrl { get; }

        string SkypeName { get; }

        string BaseImageUrl { get; }
        string BaseApiUrl { get; }
        string BaseIdentityUrl { get; }

        string ImageDefaultPlaceholder { get; }
        string ImageProfilePlaceholder { get; }

        string GetRegistrationReturnUrl(string returnUrl);
        string GetLoginReturnUrl(string returnUrl);
    }
}
