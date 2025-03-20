public class Schedule
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    
    public int TaskId { get; set; }
    public Task? Task { get; set; }
    
    public int ShiftId { get; set; }
    public Shift? Shift { get; set; }
    
    public DayOfWeek Day { get; set; } // Enum representing the day of the week
}