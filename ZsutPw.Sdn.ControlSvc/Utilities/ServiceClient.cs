//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Utilities
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  using System.Net.Http;
  using System.Text.Json;

  public class ServiceClient
  {
    private readonly HttpClient httpClient = new HttpClient( );

    private ServiceProtocol serviceProtocol = ServiceProtocol.Http;

    private readonly string serviceHost;
    private readonly ushort servicePort;

    private const ushort httpPort = 80;
    private const ushort httpsPort = 443;

    public string User { get; set; }
    public string Password { get; set; }

    public ServiceClient( ServiceProtocol serviceProtocol, string serviceHost, int servicePort )
    {
      Debug.Assert( condition: !String.IsNullOrEmpty( serviceHost ) && servicePort >= 0 );

      if( String.IsNullOrEmpty( serviceHost ) || servicePort < 0  )
        throw new ArgumentException( );

      this.serviceProtocol = serviceProtocol;
      this.serviceHost = serviceHost;
      this.servicePort = (ushort)servicePort;
    }

    public ServiceClient( string serviceHost, int servicePort ) : this( ServiceProtocol.Http, serviceHost, servicePort )
    {
    }

    public ServiceClient( string serviceHost ) : this( serviceHost, 0 )
    {
    }

    public T CallWebService<T>( HttpMethod httpMethod, string webCallUrl )
    {
      Task<T> webServiceCall = this.CallWebServiceAsync<T>( httpMethod, webCallUrl );

      webServiceCall.Wait( );

      T result = webServiceCall.Result;

      return result;
    }

    public string CallWebService( HttpMethod httpMethod, string webCallUrl )
    {
      Task<string> webServiceCall = this.CallWebServiceAsync( httpMethod, webCallUrl );

      webServiceCall.Wait( );

      string result = webServiceCall.Result;

      return result;
    }

    public async Task<T> CallWebServiceAsync<T>( HttpMethod httpMethod, string callUrl )
    {
      string jsonResult = await this.CallWebServiceAsync( httpMethod, callUrl );

      T result = this.ConvertJson<T>( jsonResult );

      return result;
    }

    public async Task<string> CallWebServiceAsync( HttpMethod httpMethod, string callUrl )
    {
      string hostPort = ( this.servicePort == 0 ) ? serviceHost : String.Format( "{0}:{1}", this.serviceHost, this.servicePort );

      string requestUrl = String.Format( "{0}://{1}/{2}", this.serviceProtocol.ToString( ).ToLower( ), hostPort, callUrl );

      HttpRequestMessage httpRequestMessage = new HttpRequestMessage( httpMethod, requestUrl );

      this.AddHeaders( httpRequestMessage );

      HttpResponseMessage httpResponseMessage = await httpClient.SendAsync( httpRequestMessage );

      httpResponseMessage.EnsureSuccessStatusCode( );

      string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync( );

      return httpResponseContent;
    }

    private void AddHeaders( HttpRequestMessage httpRequestMessage )
    {
      httpRequestMessage.Headers.Add( "Accept", "application/json" );

      if( !String.IsNullOrEmpty( this.User ) )
      {
        string credentials = String.Format( "{0}:{1}", this.User, this.Password );

        string authorization = String.Format( "Basic {0}", EncodeTo64( credentials ) );

        httpRequestMessage.Headers.Add( "Authorization", authorization );
      }
    }

    private T ConvertJson<T>( string json )
    {
      JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions( );

      jsonSerializerOptions.PropertyNameCaseInsensitive = true;

      jsonSerializerOptions.Converters.Add( new DoubleJsonConverter( ) );

      return (T)JsonSerializer.Deserialize<T>( json, jsonSerializerOptions );
    }

    public static string EncodeTo64( string toEncode )
    {
      byte[ ] toEncodeBytes = ASCIIEncoding.ASCII.GetBytes( toEncode );

      return Convert.ToBase64String( toEncodeBytes );
    }
  }
}
