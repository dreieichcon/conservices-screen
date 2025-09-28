using System.Text;

namespace Conservices.Screen.Util;

public static class DateTimeHelper
{
	public static DateTime ToLocal(this DateTime date)
		=> TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local);

	public static string DateAndTime(this DateTime? date)
	{
		return date?.ToString("yyyy-MM-dd HH:mm") ?? string.Empty;
	}

	public static string DayAndTime(this DateTime? date)
		=> date.HasValue ? DayAndTimeInternal(date.Value) : string.Empty;

	public static string DayAndTime(this DateTime date)
		=> DayAndTimeInternal(date);

	public static string TimeDelta(this DateTime? date)
		=> date.HasValue ? TimeDeltaInternal(date.Value) : string.Empty;

	public static string TimeDelta(this DateTime date)
		=> TimeDeltaInternal(date);

	private static string DayAndTimeInternal(this DateTime date)
	{
		var day = (int)date.DayOfWeek switch
		{
			0 => "So.",
			1 => "Mo.",
			2 => "Di.",
			3 => "Mi.",
			4 => "Do.",
			5 => "Fr.",
			6 => "Sa.",
			_ => date.DayOfWeek.ToString(),
		};

		return $"{day} ({date:dd.MM}) - {date:HH:mm}";
	}

	private static string TimeDeltaInternal(this DateTime date)
	{
		var delta = date - DateTime.UtcNow;

		var sb = new StringBuilder();
		
		if (delta.TotalDays >= 1)
		{
			sb.Append($"{FormatDays(delta.Days)} ");
			sb.Append($"{FormatHours(delta.Hours)}");
			return sb.ToString();
		}
		
		sb.Append($"{FormatHours(delta.Hours)} ");
		sb.Append($"{FormatMinutes(delta.Minutes)}");
		
		return sb.ToString();
	}
	
	private static string FormatDays(int days)
		=> days > 1 ? $"{days} Tage" : $"{days} Tag";
	
	private static string FormatHours(int hours)
		=> hours switch
		{
			> 1 => $"{hours} Stunden",
			1 => $"{hours} Stunde",
			_ => "",
		};

	private static string FormatMinutes(int minutes)
		=> minutes switch
		{
			> 1 => $"{minutes} Minuten",
			1 => $"{minutes} Minute",
			_ => "Jetzt",
		};
}