namespace SharedLibrary;

public class SessionTiming
{
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public TimeOnly IrradiationDuration { get; set; }
	public bool HasTechnicalBreak { get; set; }
	public TimeOnly BreakStartTime { get; set; }
	public TimeOnly BreakEndTime { get; set; }
}