using System.Collections.Generic;
using System.IO;
using Gamanet.TestTask.Wpf.Interfaces;

namespace Gamanet.TestTask.Wpf.Logic;

public class Person
{
    public Person(string[] rawData)
    {
        IsValidData = true;
        Name = rawData[0];
        Country = rawData[1];
        Address = rawData[2];
        PostalZip = rawData[3];
        Email = rawData[4];
        Phone = rawData[5];
    }

    public Person()
    {
        IsValidData = false;
    }

    public static Person Convert(string? rawData)
    {
        var elements = rawData!.Split(",");
        return elements.Length == 6 ? new Person(elements) : new Person();
    }

    public string Name { get; init; }
    public string Country { get; init; }
    public string Address { get; init; }
    public string PostalZip { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public bool IsValidData { get; init; }
}

public class DataLoader:IDataLoader
{
    public IEnumerable<Person> Load(StreamReader reader)
    {
        while (!reader.EndOfStream)
        {
            var rawData = reader.ReadLine();

            if (false == _isValidRawData)
            {
                _isValidRawData = true;
                continue;
            }

            yield return Person.Convert(rawData);
        }
    }

    bool _isValidRawData;
}