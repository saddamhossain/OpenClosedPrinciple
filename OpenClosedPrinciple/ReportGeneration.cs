namespace OpenClosedPrinciple;

#region Not Following OCP
/* According to the Open Closed Principle, the following class design is a bad design.

 The Problems are:

 If we would like to add CSV Report Generation then we have to modify the ReportGenerationWrongWay class.
 We have to test all the functionalities of the ReportGenerationWrongWay class again to make sure that with the latest
 modification no existing functionalities have been broken.
*/

public class ReportGenerationWrongWay
{
    public ReportGenerationWrongWay(string reportType)
    {
        ReportType = reportType;
    }

    public string ReportType { get; }

    public void GenerateReport(Employee employee)
    {
        if (ReportType == "CRS")
        {
            // Report generation with employee data in Crystal Report.
        }
        if (ReportType == "PDF")
        {
            // Report generation with employee data in PDF.
        }
    }
}
#endregion


#region Following OCP

// If we design the ReportGeneration as follows then we can add as many types of new ReportGenerations without altering the existing ReportGeneration classes.
public interface IReportGeneration
{
    void GenerateReport(Employee employee);
}

public class PdfReportGeneration : IReportGeneration
{
    public void GenerateReport(Employee employee)
    {
        Console.WriteLine("Generating PDF report.");
    }
}

public class CRSReportGeneration : IReportGeneration
{
    public void GenerateReport(Employee employee)
    {
        Console.WriteLine("Generating CRS report.");
    }
}

public class CsvReportGeneration : IReportGeneration
{
    public void GenerateReport(Employee employee)
    {
        Console.WriteLine("Generating CSV report.");
    }
}
#endregion