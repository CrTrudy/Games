namespace StreetRun;

class Street : IStreet
{
    Random rand = new Random();

    List<char> _strasse = new List<char>();
    List<char> _hindernisse;
    public string Buffer { get; set; }

    public Street()
    {
        _strasse.Capacity = 101;
        for (int i = 0; i < 65; i++)
        {
            _strasse.AddRange("_");
        }
        _hindernisse = new List<char>("ȹȾɎȸȵȴ");
        Buffer = String.Join("", _strasse.GetRange(0, 60));
    }

    public void StrasseBauen()
    {
        Hindernisse();
        StrasseErweitern();
        _strasse.RemoveAt(0);
        if (_strasse.Count > 100)
        {
            _strasse.RemoveRange(80, _strasse.Count - 80);
        }
        Buffer = String.Join("", _strasse.GetRange(0, 60));
    }

    void Hindernisse()
    {
        if (rand.Next(0, 99) > 90) { _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]);
            if (rand.Next(0, 99) > 84) { _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]);
                if (rand.Next(0, 99) > 94) { _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]);
                    if (rand.Next(0, 99) > 94) { _strasse.Add(_hindernisse[rand.Next(0, _hindernisse.Count)]); }
                }
            }
            _strasse.AddRange("___");
        }
    }
    void StrasseErweitern()
    {
        if (rand.Next(0, 99) > 34) { _strasse.AddRange("_____");
            if (rand.Next(0, 99) > 44) { _strasse.AddRange("___"); }
            if (rand.Next(0, 99) > 64) { _strasse.AddRange("_"); 
                if (rand.Next(0, 99) > 74) { _strasse.AddRange("____"); }
                if (rand.Next(0, 99) > 13) { _strasse.AddRange("_"); }
                if (rand.Next(0, 99) > 25) { _strasse.AddRange("__"); }
                if (rand.Next(0, 99) > 84) { _strasse.AddRange("__"); }                
            }
        }
    }
}


