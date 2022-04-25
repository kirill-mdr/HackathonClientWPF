namespace SharedLibrary;

public class SessionData
{
	public int Id { get; set; }
	public int SessionNumber { get; set; }
	public SessionType Type;
	public string? Organization { get; set; }
	public SessionTiming Timing { get; set; }

	public string?[] ObjectID { get; set; }

	public Agent Agent { get; set; }
	public float Angle { get; set; }
	public float SessionFlowIntensity { get; set; }
	public EnvironmentIndicators Indicators { get; set; }

	public float TrackDetectorsAverage { get; set; }

	public float?[] TrackDetectors { get; set; }

	public float ODAverage { get; set; }
	public float?[] OnlineDetectors { get; set; }

	public float SessionTemperature { get; set; }
	public float Heterogeneity { get; set; }
	public float LeftHeterogeneity { get; set; }
	public float RightHeterogeneity { get; set; }
	public float Error { get; set; }
	public float K { get; set; }
}