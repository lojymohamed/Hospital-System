public class Department
{
    public int DepartmentID { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int? SupervisorID { get; set; } // nullable (important!)
}