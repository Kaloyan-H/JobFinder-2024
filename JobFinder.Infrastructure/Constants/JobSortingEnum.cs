namespace JobFinder.Infrastructure.Constants
{
    public enum JobSortingEnum
    {
        NewestFirst = 0b1,
        OldestFirst = 0b10,
        SalaryAscending = 0b100,
        SalaryDescending = 0b1000,
    }
}
