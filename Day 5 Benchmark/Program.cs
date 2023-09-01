using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Contribuente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime DataNascita { get; set; }
    public string CodiceFiscale { get; set; }
    public char Sesso { get; set; }
    public string ComuneResidenza { get; set; }
    public double RedditoAnnuale { get; set; }
    public double ImpostaDaVersare { get; private set; }

    public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
    {
        Nome = nome;
        Cognome = cognome;
        DataNascita = dataNascita;
        CodiceFiscale = codiceFiscale;
        Sesso = sesso;
        ComuneResidenza = comuneResidenza;
        RedditoAnnuale = redditoAnnuale;
        CalcolaImposta();
    }

    private void CalcolaImposta()
    {
        if (RedditoAnnuale <= 15000)
        {
            ImpostaDaVersare = RedditoAnnuale * 0.23;
        }
        else if (RedditoAnnuale <= 28000)
        {
            ImpostaDaVersare = 3450 + (RedditoAnnuale - 15000) * 0.27;
        }
        else if (RedditoAnnuale <= 55000)
        {
            ImpostaDaVersare = 6960 + (RedditoAnnuale - 28000) * 0.38;
        }
        else if (RedditoAnnuale <= 75000)
        {
            ImpostaDaVersare = 17220 + (RedditoAnnuale - 55000) * 0.41;
        }
        else
        {
            ImpostaDaVersare = 25420 + (RedditoAnnuale - 75000) * 0.43;
        }
    }
}

class Program
{
    static List<Contribuente> contribuenti = new List<Contribuente>();

    static void Main(string[] args)
    {
        bool continua = true;

        while (continua)
        {
            
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" --- C A L C O L A T O R E   A U T O M A T I C O   D I   P O V E R T A' --- ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Menu:");
            Console.WriteLine(" ");
            Console.WriteLine("1) Inserimento di una nuova dichiarazione di un contribuente");
            Console.WriteLine(" ");
            Console.WriteLine("2) Lista completa di tutti i poveri analizzati");
            Console.WriteLine(" ");
            Console.WriteLine("3) Esci");
           

            int scelta;
            if (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Input non valido. Inserisci un numero valido.");
                continue;
            }

            switch (scelta)
            {
                case 1:
                    InserisciContribuente();
                    break;
                case 2:
                    StampaContribuenti();
                    break;
                case 3:
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }

    static void InserisciContribuente()
    {
        Console.WriteLine("Inserisci il nome:");
        string nome;
        do
        {
            nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome) && nome.All(char.IsLetter))
            {
                break; 
            }
            Console.WriteLine("Nome non valido. Il campo non può contenere dei numeri.");
        } while (true);

        Console.WriteLine("Inserisci il cognome:");
        string cognome;
        do
        {
            cognome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(cognome) && cognome.All(char.IsLetter))
            {
                break; 
            }
            Console.WriteLine("Cognome non valido. Il campo non può contenere dei numeri.");
        } while (true);


        DateTime dataNascita;
        while (true)
        {
            Console.WriteLine("Inserisci la data di nascita (GG/MM/AAAA):");
            if (DateTime.TryParse(Console.ReadLine(), out dataNascita))
            {
                break;
            }
            else
            {
                Console.WriteLine("Formato data non valido. Inserire una data valida.");
            }
        }

        Console.WriteLine("Inserisci il codice fiscale:");
        string codiceFiscale;
        do
        {
            codiceFiscale = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(codiceFiscale) && codiceFiscale.Length == 16)
            {
                break; 
            }
            Console.WriteLine("Codice fiscale non valido. Il codice fiscale deve essere composto da 16 caratteri alfanumerici.");
        } while (true);


        char sesso;
        while (true)
        {
            Console.WriteLine("Inserisci il sesso (M/F):");
            if (char.TryParse(Console.ReadLine(), out sesso) && (sesso == 'M' || sesso == 'F'))
            {
                break;
            }
            else
            {
                Console.WriteLine("Sesso non valido. Inserisci 'M' o 'F'.");
            }
        }

        Console.WriteLine("Inserisci il comune di residenza:");
        string comuneResidenza;
        do
        {
            comuneResidenza = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(comuneResidenza) && comuneResidenza.All(char.IsLetter))
            {
                break; 
            }
            Console.WriteLine("Comune di residenza non valido. Il campo non può contenere dei numeri.");
        } while (true);


        double redditoAnnuale;
        while (true)
        {
            Console.WriteLine("Inserisci il reddito annuale:");
            if (double.TryParse(Console.ReadLine(), out redditoAnnuale))
            {
                break;
            }
            else
            {
                Console.WriteLine("Reddito non valido. Inserisci un numero valido.");
            }
        }

        var contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);
        contribuenti.Add(contribuente);

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("==================================================");
        Console.WriteLine(" ");
        Console.WriteLine("CALCOLO DELL’IMPOSTA DA VERSARE:");
        Console.WriteLine(" ");
        Console.WriteLine($"Poveraccio/a: {contribuente.Nome} {contribuente.Cognome},");
        Console.WriteLine($"Nato/a il {contribuente.DataNascita:dd/MM/yyyy} ({contribuente.Sesso}),");
        Console.WriteLine($"Residente in {contribuente.ComuneResidenza},");
        Console.WriteLine($"Codice fiscale: {contribuente.CodiceFiscale}");
        Console.WriteLine($"Reddito dichiarato (SEH CREDICI): {contribuente.RedditoAnnuale}");
        Console.WriteLine(" ");
        Console.WriteLine("()__()");
        Console.WriteLine("( O.O) " + " " + $"IMPOSTA DA VERSARE: Euro {contribuente.ImpostaDaVersare}" );
        Console.WriteLine("/ ( )  ");

        Console.WriteLine(" ");
        Console.WriteLine("==================================================");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    static void StampaContribuenti()
    {
        if (contribuenti.Count == 0)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Nessun contribuente è stato analizzato.");
            Console.WriteLine(" ");
        }
        else
        {
            Console.WriteLine("Elenco dei poveri analizzati:");
            foreach (var contribuente in contribuenti)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine($"Poveraccio/a: {contribuente.Nome} {contribuente.Cognome},");
                Console.WriteLine($"Nato/a il {contribuente.DataNascita:dd/MM/yyyy} ({contribuente.Sesso}),");
                Console.WriteLine($"Residente in {contribuente.ComuneResidenza},");
                Console.WriteLine($"Codice fiscale: {contribuente.CodiceFiscale}");
                Console.WriteLine($"Reddito dichiarato (SEH CREDICI): {contribuente.RedditoAnnuale}");
                Console.WriteLine($"IMPOSTA DA VERSARE: Euro {contribuente.ImpostaDaVersare}");
                Console.WriteLine("==================================================");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
        }
    }
}