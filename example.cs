namespace Events.Crawls
{
	public class CrawlStarted : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
	}

	public class CrawlEnded : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
	}
}

namespace Events.Pages
{
	public class PageAdded : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public string Hash { get; set; }
		public string ContentLocation { get; set; }
		public string ContentType { get; set; }
		public long FileSize { get; set; }
		public DateTime LastModified { get; set; }
	}

	public class PageSeen : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
	}

	public class PageContentChanged : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
		public string Hash { get; set; }
		public string NewHash { get; set; }
		public string NewContent { get; set; }
	}

	public class PageTitleChanged : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
		public string NewTitle { get; set; }
	}

	public class PageRemoved : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
	}
}

namespace Events.Links
{
	public class LinkSeen : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
	}

	public class LinkRemoved : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
	}

	public class LinkAdded : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
	}

	public class LinkBecameOkay : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
	}

	public class LinkBecameBroken : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Url { get; set; }
		public int Status { get; set; }
		public string Message { get; set; }
	}
}

namespace Events.Spellcheck
{
	public class SpellcheckOrderedForPage : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Page { get; set; }
	}

	public class NewMisspellingFound : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Page { get; set; }
		public string Word { get; set; }
		public string Type { get; set; }
	}

	public class ExistingMisspellingRemoved : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Page { get; set; }
		public string Word { get; set; }
		public string Type { get; set; }
	}

	public class SpellingContentChanged : IEvent
	{
		public string EventId { get; set; }
		public string CorrelationId { get; set; }
		public int Version { get; set; }
		public DateTime Time { get; set; }
		public string Page { get; set; }
		public string Hash { get; set; }
		public string NewHash { get; set; }
		public string NewContent { get; set; }
	}
}
