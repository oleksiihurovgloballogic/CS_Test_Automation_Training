namespace Homework_05
{
    internal class Hometask_05
    {
        // --- class Car -------------------------------------------------------

        /// <summary>
        /// Origin description of the Motor Vehicle (Automobile)
        /// by it's VIN (Vehicle Identification Number).
        /// https://en.wikipedia.org/wiki/Vehicle_identification_number
        /// </summary>
        public class Car
        {
            // --- Attributes --------------------------------------------------

            // VIN (Vehicle Identification Number)
            public string VIN { get; }
            // VIN: WMI (World Manufacturer Identifier)
            internal string WMI { get; }
            // VIN: VDS (Vehicle Descriptor Section)
            internal string VDS { get; }
            // VIN: VIS (Vehicle Identifier Section)
            internal string VIS { get; }

            // Descriptive structure for loading list of WMI codes
            internal class WMI_Codes
            {
                public string Code;
                public string Manufacturer;
                public string Country;

                // internal loader
                public static WMI_Codes FromCsv(string csvLine)
                {
                    string[] values = csvLine.Split(',');
                    WMI_Codes WMI = new WMI_Codes();
                    WMI.Code = values[0];
                    WMI.Manufacturer = values[1];
                    WMI.Country = values[2];
                    return WMI;
                }
            }

            // General list of WMI codes, gotten from http://www.ship.gr/gear/vin.html
            internal static List<WMI_Codes> WMICodesList = File.ReadAllLines("WMI_Codes.csv")
                .Skip(1)
                .Select(values => WMI_Codes.FromCsv(values))
                .ToList();
            // Particular WMI code index for the Car instance
            internal int WMICodeIndex { get; set; }

            // --- Constructor -------------------------------------------------

            public Car(string VIN)
            {
                // validation
                if (VIN.Length != 17) throw new ArgumentException(
                    "Provided VIN contains other than 17 symbols exactly.");

                // parsing the VIN number
                this.VIN = VIN.ToUpper();
                this.WMI = this.VIN[0..3];
                this.VDS = this.VIN[3..9];
                this.VIS = this.VIN[9..16];

                // searching for the particular WMI code index in the general list of codes
                WMICodeIndex = SearchForWMICodeIndex();
            }

            private int SearchForWMICodeIndex()
            {
                int index = -1;
                for (var range = 4; range > 0; range--)
                {
                    string code = VIN[0..range];
                    int i = 0;
                    foreach (WMI_Codes WMI in Car.WMICodesList)
                    {
                        if (WMI.Code == code)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    if (index != -1) break;
                }
                return index;
            }

            // --- Calculation Methods -----------------------------------------

            public string GetWorldManufacturerRegion()
            {
                if ('A' <= WMI[0] && WMI[0] <= 'H') return "Africa";
                else if ('J' <= WMI[0] && WMI[0] <= 'R') return "Asia";
                else if ('S' <= WMI[0] && WMI[0] <= 'Z') return "Europe";
                else if (
                    '1' <= WMI[0] && WMI[0] <= '5' ||
                    '7' == WMI[0] && (WMI[1] >= 'F' || WMI[1] == '0')
                ) return "North America";
                else if (
                    '6' == WMI[0] ||
                    '7' == WMI[0] && ('A' <= WMI[1] && WMI[1] <= 'E')
                ) return "Oceania";
                else if ('8' <= WMI[0] && WMI[0] <= '9') return "South America";
                else return "N/A";
            }

            public string GatWorldManufacturerCountry()
            {
                if (WMICodeIndex != -1)
                {
                    return WMICodesList[WMICodeIndex].Country;
                }
                else return "N/A";
            }

            public string GetWorldManufacturerModel()
            {
                if (WMICodeIndex != -1)
                {
                    return WMICodesList[WMICodeIndex].Manufacturer;
                }
                else return "N/A";
            }

            public string GetModelYear()
            {
                int currentYear = DateTime.Now.Year;
                int ordinal = char.ConvertToUtf32(VIN[9].ToString(), 0);
                int year = -1;

                // believe me, it have to be hardcoded in this way
                switch (VIN[9])
                {
                    case >= 'A' and <= 'H': { year = ordinal - 65 + 1980; break; }
                    case >= 'J' and <= 'N': { year = ordinal - 65 + 1980 - 1; break; }
                    case 'P': { year = ordinal - 65 + 1980 - 2; break; }
                    case >= 'R' and <= 'T': { year = ordinal - 65 + 1980 - 3; break; }
                    case >= 'V' and <= 'Y': { year = ordinal - 65 + 1980 - 4; break; }
                    case >= '1' and <= '9': { year = ordinal - 49 + 2001; break; }
                    case '0': { year = ordinal - 48 + 1980; break; }
                        //default: { year = -1; break; }
                }

                if (year != -1)
                {
                    while (currentYear - year >= 30) year += 30;
                    return year.ToString();
                }
                else return "N/A";
            }

            // --- Output Methods ----------------------------------------------

            public void PrintVINTranscription()
            {
                Console.WriteLine();
                Console.WriteLine($"                                  Plant                          ");
                Console.WriteLine($"   Region/Maker                Year │ Vehicle's production number");
                Console.WriteLine($" Country │ Type      Check Digit │  │ (serial number)            ");
                Console.WriteLine($"      │  │  │                 │  │  │ ────────────────┐          ");
                Console.WriteLine($"   ╔═════════════════════════════════════════════════════╗       ");
                Console.WriteLine($"   ║  {string.Join("  ", VIN.ToCharArray())}  ║       ");
                Console.WriteLine($"   ╚═════════════════════════════════════════════════════╝       ");
                Console.WriteLine($"      └─────┘  └───────────┘  └───────────────────────┘          ");
                Console.WriteLine($"        WMI         VDS                  VIS                     ");
                Console.WriteLine($"       World      Vehicle              Vehicle                   ");
                Console.WriteLine($"   Manufacturer  Descriptor           Identifier                 ");
                Console.WriteLine($"    Identifier    Section              Section                   ");
                Console.WriteLine();
            }

            public void PrintCarInfo()
            {
                Console.WriteLine($"VIN:\t\t\t{VIN}");
                Console.WriteLine($"WMI | VDS | VIS:\t{WMI} | {VDS} | {VIS}");
                Console.WriteLine($"Manufacturer Region:\t{GetWorldManufacturerRegion()}");
                Console.WriteLine($"Manufacturer Country:\t{GatWorldManufacturerCountry()}");
                Console.WriteLine($"Manufacturer Model:\t{GetWorldManufacturerModel()}");
                Console.WriteLine($"Model Year:\t\t{GetModelYear()}");
            }
        }

        // --- Main ------------------------------------------------------------    

        public static void Main()
        {
            //var myCar = new Car("WP0ZZZ99ZTS392124");
            //var myCar = new Car("5GZCZ43D13S812715");
            var myCar = new Car("5YJYGDEF2LFR00942");
            myCar.PrintVINTranscription();
            myCar.PrintCarInfo();
        }
    }
}
