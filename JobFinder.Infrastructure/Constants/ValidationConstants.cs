namespace JobFinder.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        public static class JobConstants
        {
            public const int TitleMinLength = 8;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 30;
            public const int DescriptionMaxLength = 300;

            public const int RequirementsMinLength = 30;
            public const int RequirementsMaxLength = 700;

            public const int ResponsibilitiesMinLength = 30;
            public const int ResponsibilitiesMaxLength = 700;

            public const int BenefitsMinLength = 30;
            public const int BenefitsMaxLength = 700;

            public const int SalaryMinValue = 0;
            public const int SalaryMaxValue = 100000;
        }

        public static class CategoryConstants
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;
        }

        public static class EmploymentTypeConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;
        }

        public static class ApplicationConstants
        {
            public const int CoverLetterMinLength = 50;
            public const int CoverLetterMaxLength = 2000;
        }

        public static class CompanyConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const int IndustryMinLength = 10;
            public const int IndustryMaxLength = 60;
        }

        public static class MessageConstants
        {
            public const int ContentMinLength = 1;
            public const int ContentMaxLength = 1000;
        }

        public static class AppUserConstants
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 30;

            public const int BioMinLength = 20;
            public const int BioMaxLength = 300;

            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;

            public const int EmailMinLength = 4;
            public const int EmailMaxLength = 320;

            public const int PasswordMinLength = 8;
            public const int PasswordMaxLength = 100;
        }
    }
}
