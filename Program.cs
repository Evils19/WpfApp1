
public class  Program
{
    static void Main(string[] args)
    {
        string key = "CABF";
        int[] key1 = { 2, 0, 1 };
       Cesar cesar = new Cesar("Testam algoritmul de criptare", key );
       cesar.Cripto();
       cesar.Decripto();
       Console.WriteLine(cesar.Cripto());
       Console.WriteLine(cesar.Decripto());


    }
}
public class Cesar
{
    private string? _skey;
    private int[] _key= new int[26];
 
    private char[] _alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private string? _message;

    public Cesar(string message, string Skey)
    {
        _message = message;
        _skey = Skey;
    }
    public Cesar(string message, string Skey, string Skey2)
    {
        _message = message;
        _skey = Skey;
      
    }
    public Cesar(string message, int[] Key)
    { 
        _message = message;
        _key = Key;
    }   public Cesar(string message, int[] Key, int[] Key2)
    { 
        _message = message;
        _key = Key;
     
    }

   

    public int[] ConverKey(string Skey)
    {
        int k = 0;
        _skey = Skey;
        _skey = _skey.ToUpper();
        _key = new int[_skey.Length]; 
        for (int i = 0; i < _skey.Length; i++) 
        {
            for (int j = 0; j < _alphabetUpper.Length; j++) 
            {
                if (k < Skey.Length && _alphabetUpper[j] == Skey[k])
                {
                    _key[k] = j;
                    k++; 
                    break;
                }
            }
        }

        return _key;
    }
public string Cripto()
{
    int[] key = (_skey == null) ? _key : ConverKey(_skey);
    
    int keyIndex = 0;

    string criptoMessage = "";
    foreach (char character in _message ?? "")
    {
        if (character == ' ')
        {
            criptoMessage += " ";
        }
        else
        {
            char upperCaseCharacter = char.ToUpper(character);
            int alphabetIndex = Array.IndexOf(_alphabetUpper, upperCaseCharacter);
            if (alphabetIndex != -1)
            {
                criptoMessage += _alphabetUpper[(alphabetIndex + key[keyIndex]) % 26];
                keyIndex = (keyIndex + 1) % key.Length;
            }
        }
    }
    _message = criptoMessage;
    return _message;
}
public string Decripto()
{
    string temp;
    int[] key = (_skey == null) ? _key : ConverKey(_skey);
    int keyIndex = 0; // Indexul pentru următoarea poziție din cheie
   string? decriptomesaj = "";
   foreach (var character in _message ?? "")
   {
       if (character==' ')
       {
           decriptomesaj += " ";
       }
       else
       {
           char upperCaseCharacter = char.ToUpper(character);
           int alphabetIndex = Array.IndexOf(_alphabetUpper, upperCaseCharacter);
           if (alphabetIndex !=  _alphabetUpper.Length)
           {
               temp = _alphabetUpper[(alphabetIndex - key[keyIndex] + 26) % 26].ToString();
               decriptomesaj += temp;
               keyIndex = (keyIndex + 1) % key.Length;
               
           }

       }
       
   }

    _message = decriptomesaj;
    return _message;
}

}