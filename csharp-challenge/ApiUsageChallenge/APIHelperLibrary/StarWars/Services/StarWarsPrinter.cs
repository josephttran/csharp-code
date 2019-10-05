using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace APIHelperLibrary.StarWars.Services
{
    public class StarWarsPrinter
    {
        static public void ShowPrettyFullJson(string serializeJson)
        {
            Console.WriteLine();
            Console.WriteLine(serializeJson);
        }

        static public void ShowPrettyFilteredJson(string serializeJson)
        {
            List<string> filteredProperties = new List<string> { "name", "gender", "birth_year", "films", "vehicles" };

            var jsonWriterOption = new JsonWriterOptions 
            { 
                Indented = true 
            };

            var options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream, jsonWriterOption))
                {
                    writer.WriteStartObject();

                    using (JsonDocument document = JsonDocument.Parse(serializeJson, options))
                    {
                        foreach (string propertyName in filteredProperties)
                        {
                            if (document.RootElement.TryGetProperty(propertyName, out JsonElement propertyValue))
                            {
                                if (propertyValue.ValueKind.ToString() == "Array")
                                {
                                    writer.WritePropertyName(propertyName);
                                    writer.WriteStartArray();

                                    foreach (var value in propertyValue.EnumerateArray())
                                    {
                                        writer.WriteStringValue(value.ToString());
                                    }

                                    writer.WriteEndArray();
                                }
                                else 
                                {
                                    writer.WriteString(propertyName, propertyValue.ToString());
                                }
                            }
                        }
                    }

                    writer.WriteEndObject();
                }

                string json = Encoding.UTF8.GetString(stream.ToArray());

                Console.WriteLine(json);
            }
        }
    }
}
