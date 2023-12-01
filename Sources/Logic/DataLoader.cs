using System;
using System.Collections.Generic;
using System.IO;
using Gamanet.TestTask.Wpf.Interfaces;
using Serilog;

namespace Gamanet.TestTask.Wpf.Logic;

public class Person
{
    public Person(string? rawData)
    {
        var elements = rawData!.Split(",");
        if (elements.Length != 6) throw new Exception("Not valid raw data");

        Name = elements[0];
        Country = elements[1];
        Address = elements[2];
        PostalZip = elements[3];
        Email = elements[4];
        Phone = elements[5];
    }

    public string Name { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string PostalZip { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
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

            yield return new Person(rawData);
        }
    }

    bool _isValidRawData;
}