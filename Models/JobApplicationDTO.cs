namespace JobTrackerApi.Models;

public class JobApplicationDTO
{
    public int Id{ get; set; }
    public string CompanyName{ get; set; }
    public string PositionTitle{ get; set; }
    public string Location{ get; set; }
    public string JobUrl{ get; set; }
    public string SalaryRange{ get; set; }
    public string Status{ get; set; }
    public DateTime DateApplied{ get; set; }
}