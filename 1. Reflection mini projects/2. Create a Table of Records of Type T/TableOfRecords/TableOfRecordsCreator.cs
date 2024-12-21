using System.Globalization;
using System.Reflection;

namespace TableOfRecords;

/// <summary>
/// Presents method that write in table form to the text stream a set of elements of type T.
/// </summary>
public static class TableOfRecordsCreator
{
    /// <summary>
    /// Write in table form to the text stream a set of elements of type T (<see cref="ICollection{T}"/>),
    /// where the state of each object of type T is described by public properties that have only build-in
    /// type (int, char, string etc.)
    /// </summary>
    /// <typeparam name="T">Type selector.</typeparam>
    /// <param name="collection">Collection of elements of type T.</param>
    /// <param name="writer">Text stream.</param>
    /// <exception cref="ArgumentNullException">Throw if <paramref name="collection"/> is null.</exception>
    /// <exception cref="ArgumentNullException">Throw if <paramref name="writer"/> is null.</exception>
    /// <exception cref="ArgumentException">Throw if <paramref name="collection"/> is empty.</exception>
    public static void WriteTable<T>(ICollection<T>? collection, TextWriter? writer)
    {
        // Validate input parameters
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(writer);

        if (collection.Count == 0)
        {
            throw new ArgumentException("The collection is empty.", nameof(collection));
        }

        // Get all valid properties of type T and supported data types
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType.IsPrimitive
                        || p.PropertyType == typeof(string)
                        || p.PropertyType == typeof(decimal)
                        || p.PropertyType == typeof(DateTime))
            .ToArray();

        if (properties.Length == 0)
        {
            throw new ArgumentException("Type T must have at least one public property of a supported type.", nameof(collection));
        }

        // Precompute alignment and column widths
        var alignment = new Dictionary<string, bool>();
        var columnWidths = new Dictionary<string, int>();

        foreach (var property in properties)
        {
            bool isRightAligned = property.PropertyType == typeof(int) || property.PropertyType == typeof(decimal) ||
                                  property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(byte);
            alignment[property.Name] = isRightAligned;

            int maxContentLength = collection.Max(item =>
            {
                var value = property.GetValue(item);
                return value switch
                {
                    DateTime date => date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).Length,
                    decimal dec => dec.ToString(CultureInfo.InvariantCulture).Length,
                    byte b => b.ToString(CultureInfo.InvariantCulture).Length,
                    _ => (value?.ToString() ?? string.Empty).Length,
                };
            });
            columnWidths[property.Name] = Math.Max(property.Name.Length, maxContentLength);
        }

        // Prepare reusable lines
        string borderLine = "+" + string.Join("+", properties.Select(p => new string('-', columnWidths[p.Name] + 2))) + "+";
        string headerLine = "|" + string.Join("|", properties.Select(p => " " + p.Name.PadRight(columnWidths[p.Name]) + " ")) + "|";

        writer.WriteLine(borderLine);
        writer.WriteLine(headerLine);
        writer.WriteLine(borderLine);

        // Write each data row with precomputed alignment
        foreach (var item in collection)
        {
            string dataLine = "|" + string.Join("|", properties.Select(p =>
            {
                var value = p.GetValue(item);
                string content = value switch
                {
                    DateTime date => date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    decimal dec => dec.ToString(CultureInfo.InvariantCulture),
                    byte b => b.ToString(CultureInfo.InvariantCulture),
                    _ => value?.ToString() ?? string.Empty,
                };

                return alignment[p.Name]
                    ? content.PadLeft(columnWidths[p.Name] + 1) + " "
                    : " " + content.PadRight(columnWidths[p.Name]) + " ";
            })) + "|";

            writer.WriteLine(dataLine);
            writer.WriteLine(borderLine);
        }
    }
}
