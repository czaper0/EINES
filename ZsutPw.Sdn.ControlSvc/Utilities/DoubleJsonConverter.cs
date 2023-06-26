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
  using System.Threading.Tasks;

  using System.Text.Json;
  using System.Text.Json.Serialization;

  public class DoubleJsonConverter : JsonConverter<double>
  {
    public override double Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
      if( reader.TokenType == JsonTokenType.String )
      {
        string stringValue = reader.GetString( );

        if( double.TryParse( stringValue, out double value ) )
        {
          return value;
        }
      }
      else if( reader.TokenType == JsonTokenType.Number )
      {
        return reader.GetDouble( );
      }

      throw new JsonException( );
    }

    public override void Write( Utf8JsonWriter writer, double value, JsonSerializerOptions options )
    {
      writer.WriteNumberValue( value );
    }
  }
}
