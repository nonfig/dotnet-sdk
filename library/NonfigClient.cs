using System;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace library
{
  public partial class IConfigurationResponse
	{
		[JsonProperty("count")]
		public double Count
		{
			get;
			set;
		}

		[JsonProperty("data")]
		public List<IConfiguration> Data
		{
			get;
			set;
		}

		[JsonProperty("error")]
		public string Error
		{
			get;
			set;
		}

		[JsonProperty("success")]
		public bool Success
		{
			get;
			set;
		}
	}

	public partial class IConfiguration
	{
		[JsonProperty("data")]
		public string Data
		{
			get;
			set;
		}

		[JsonProperty("description")]
		public string Description
		{
			get;
			set;
		}

		[JsonProperty("fullyQualifiedName")]
		public string FullyQualifiedName
		{
			get;
			set;
		}

		[JsonProperty("id")]
		public string Id
		{
			get;
			set;
		}

		[JsonProperty("label")]
		public string[] Label
		{
			get;
			set;
		}

		[JsonProperty("name")]
		public string Name
		{
			get;
			set;
		}

		[JsonProperty("path")]
		public string Path
		{
			get;
			set;
		}

		[JsonProperty("type")]
		public string Type
		{
			get;
			set;
		}

		[JsonProperty("version")]
		public double Version
		{
			get;
			set;
		}
	}

	internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
  public class NonfigClient
  {
    private string _appSecret;
    private string _appId;
    private string _baseUri;
    private string _header;
    private RestClient _client;

    public NonfigClient(string uri, string appSecret, string appId)
    {
      _appId = appId;
      _appSecret = appSecret;
      _baseUri = uri;
      _header = String.Format("Bearer {0}:{1}", _appId, _appSecret);

      _client = new RestClient(_baseUri);
    }

    private IConfigurationResponse getRequest(string path) {
      var request = new RestRequest(path, Method.GET);
			request.AddHeader("Authorization", _header);

      var response = this._client.Execute(request);

      return JsonConvert.DeserializeObject<IConfigurationResponse>(response.Content, library.Converter.Settings);
    }
    public int Add(int a, int b)
    {
      return a + b;
    }
    public int Sub(int a, int b)
    {
      return a - b;
    }

    public IConfigurationResponse findByName(string name)
    {
      return this.getRequest(String.Format("configurations/name/{0}", name));
    }

    public IConfigurationResponse findByPath(string path)
    {
      return this.getRequest(String.Format("configurations/path/{0}", path));
    }
    public IConfigurationResponse findById(string id)
    {
      return this.getRequest(String.Format("configurations/id/{0}", id));
    }
    public IConfigurationResponse findByLabels(string[] labels)
    {
      return this.getRequest(String.Format("configurations/labels/{0}", String.Join(",", labels)));
    }
  }
}
